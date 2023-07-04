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


    public void Set(Level level)
    {
        _width = level.Width;
        _height = level.Height;
        _cubes = new Cube[_width, _height];
    }

   


}
