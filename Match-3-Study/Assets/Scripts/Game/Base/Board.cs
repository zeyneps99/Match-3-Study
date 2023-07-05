using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    private int _width, _height;
    private float _cubeWidth;
    private Cube[,] _cubes;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private RectTransform _grid;
    [SerializeField] private Transform _cubeContainer;
    private ObjectPool<Cube> _cubePool = new ObjectPool<Cube>();


    public Level Level;

    public void Set(Level level)
    {
        _width = level.Width;
        _height = level.Height;
        _cubes = new Cube[_width, _height];

        if (_cubeContainer.TryGetComponent<GridLayoutGroup>(out var l))
        {
            l.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            l.constraintCount = _width;

            if(_cubePrefab.TryGetComponent<RectTransform>(out var cubeRT))
            {
                _cubeWidth = cubeRT.rect.width;
                l.cellSize = Vector2.one * _cubeWidth;
            }
        }

        GenerateCubes();
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        if(_grid != null)
        {
            _grid.sizeDelta = new Vector2(_height + .25f, _width + .25f) * _cubeWidth;
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
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                _cubePool.CreateInstance(_cubePrefab);
                Cube newCube = _cubePool.Get();
                newCube.name = "Cube - " + i + " , " + j;
                newCube.transform.SetParent(_cubeContainer);
                newCube.transform.localScale = Vector2.one;
                var type = (CubeTypes)UnityEngine.Random.Range(1, 6);
                newCube.SetType(type);
                _cubes[i, j] = newCube;

            }
            
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
