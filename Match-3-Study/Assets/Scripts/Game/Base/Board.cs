using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    private int _width, _height;
    private Cube[,] _cubes;
    private Grid[,] _grids;
    [SerializeField] private GameObject _gridPrefab;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _gridContainer;
    [SerializeField] private Transform _cubeContainer;

    private ObjectPool<Cube> _cubePool = new ObjectPool<Cube>();

    public void Set(Level level)
    {
        _width = level.Width;
        _height = level.Height;
        _cubes = new Cube[_width, _height];
        _grids = new Grid[_width, _height];

         if (_cubeContainer.TryGetComponent<GridLayoutGroup>(out var l))
        {
            l.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            l.constraintCount = _width;

        }

        GenerateGrids();
        GenerateCubes();
    }

    private void GenerateGrids()
    {
        SetGridLayout(_gridContainer);
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                GameObject go = Instantiate(_gridPrefab, _gridContainer);
                if (go.TryGetComponent<Grid>(out Grid grid))
                {
                    grid.name = "Grid - " + i + " , " + j;
                    grid.Position = new Vector2Int(i, j);
                    _grids[i, j] = grid;
                }

            }
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
        foreach (Grid grid in _grids)
        {
            _cubePool.CreateInstance(_cubePrefab);
            Cube newCube = _cubePool.Get();

            newCube.name = "Cube - " + grid.Position.x + " , " + grid.Position.y;
            newCube.transform.SetParent(_cubeContainer);
            newCube.transform.position = grid.transform.position;
            var type = (CubeTypes)UnityEngine.Random.Range(1, 6);
            newCube.SetType(type);
            _cubes[grid.Position.x, grid.Position.y] = newCube;
        }
    }

    

    private void SetGridLayout(Transform container)
    {
        if (container.TryGetComponent<GridLayoutGroup>(out var layout))
        {
            layout.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            layout.constraintCount = _width;

        }
    }
}
