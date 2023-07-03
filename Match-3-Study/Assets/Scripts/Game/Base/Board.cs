using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private int _width, _height;
    private Cube[,] _cubes;
    private GameObject _gridPrefab;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private GameObject _container;

    public void Init(Level level)
    {

        _width = level.Width;
        _height = level.Height;
        _cubes = new Cube[_width, _height];
        _gridPrefab = Resources.Load<GameObject>("Prefabs/Grid");
        SetBoard(_width, _height);

    }

    private void SetBoard(int width, int height)
    {
        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2Int pos = new Vector2Int(i, j);
                GameObject grid = Instantiate(_gridPrefab);
                grid.transform.parent = _container.transform;
                grid.name = "Grid - " + i + " , " + j;
                
            }
        }
    }


}
