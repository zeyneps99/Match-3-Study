using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{

    private float _cubeWidth;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private RectTransform _grid;
    [SerializeField] private Transform _cubeContainer;
    private ObjectPool<Cube> _cubePool = new ObjectPool<Cube>();


    public Level Level;
    public int Width, Height;
    public Cube[,] Cubes;

    public void Set(Level level)
    {
        Width = level.Width;
        Height = level.Height;
        Cubes = new Cube[Width, Height];
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

                _cubePool.CreateInstance(_cubePrefab);
                Cube newCube = _cubePool.Get();
                newCube.name = "Cube - " + i + " , " + j;
                newCube.transform.SetParent(_cubeContainer);
                newCube.transform.localScale = Vector2.one;
                var type = (CubeTypes)UnityEngine.Random.Range(1, 6);
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
            if (_cubePrefab.TryGetComponent<RectTransform>(out var cubeRT))
            {
                _cubeWidth = cubeRT.rect.width;
                layout.cellSize = Vector2.one * _cubeWidth;
            }
        }
    }



}
