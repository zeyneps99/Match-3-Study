using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : Entity
{

    private float _cubeWidth;
    [SerializeField] private GameObject _genericCubePrefab;
    [SerializeField] private RectTransform _grid;
    [SerializeField] private Transform _cubeContainer;

    public Level Level;
    public int Width, Height;
    public Cube[,] Cubes;

    public void Set(Level level)
    {
        Width = level.Width;
        Height = level.Height;
        Cubes = new Cube[Width, Height];
        PoolManager.Instance?.CreatePoolInstance(_genericCubePrefab);

        GenerateCubes();
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        if (_grid != null)
        {
            _grid.sizeDelta = new Vector2(Width + .25f, Height + .25f) * _cubeWidth;
        }
    }
    //can also extract specified order of cubes from json file for further implementations
    private void GenerateCubes()
    {
        if (_cubeContainer == null)
        {
            return;
        }
        SetGridLayout(_cubeContainer);
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                var type = (CubeTypes)UnityEngine.Random.Range(1, 6);
                GenericCube newCube = (GenericCube) PoolManager.Instance.GetPooledObject(type);
                newCube.name = "Cube - " + i + " , " + j;
                newCube.transform.SetParent(_cubeContainer);
                newCube.transform.localScale = Vector2.one;
                newCube.SetType(type);
                newCube.Position = new Vector2Int(i, j);
                Cubes[i, j] = newCube;
            }

        }
    }

    private void SetGridLayout(Transform container)
    {
        if (container.TryGetComponent<GridLayoutGroup>(out var layout))
        {
            layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            layout.constraintCount = Width;
            if (_genericCubePrefab.TryGetComponent<RectTransform>(out var cubeRT))
            {
                _cubeWidth = cubeRT.rect.width;
                layout.cellSize = Vector2.one * _cubeWidth;
            }
        }
    }

    public void Enable(bool isEnable)
    {
        foreach (Cube cube in Cubes)
        {
            cube.Enable(isEnable);
        }
    }

    public void HandleMatch(List<Cube> matchList)
    {
        foreach(Cube matchedCube in matchList)
        {
            matchedCube.Match();
            PoolManager.Instance.ReturnToPool(matchedCube);
        }
    }

}
