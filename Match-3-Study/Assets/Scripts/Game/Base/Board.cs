using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    private int _width, _height;
    private Cube[,] _cubes;
    
    [SerializeField] private GameObject _gridPrefab;
    [SerializeField] private Transform _container;

    private ObjectPool<Cube> _cubePool = new ObjectPool<Cube>();

    public void Set(Level level)
    {
        _width = level.Width;
        _height = level.Height;
        _cubes = new Cube[_width, _height];

        if (_container.TryGetComponent<GridLayoutGroup>(out var layout))
        {
            layout.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            layout.constraintCount = _width;

        }

        GenerateGrids();
    }

    private void GenerateGrids()
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                GameObject go = Instantiate(_gridPrefab, _container);
                if (go.TryGetComponent<Grid>(out Grid grid))
                {
                    grid.Position = new Vector2Int(i, j);
                }

            }
        }
    }

}
