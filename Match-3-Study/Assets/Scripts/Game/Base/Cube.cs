using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Cube : Item, IMatchable
{

    public CubeTypes Type;
    public bool IsVisited;
    public Vector2Int Position;

    private const string _spritePath = "Sprites/Cubes/";
    private const string _spritePrefix = "cube_";
    private Image Image;


   

    public void SetType(CubeTypes type)
    {
        Type = type;
        Image = GetComponent<Image>();
        var sprite = Resources.Load<Sprite>(_spritePath + _spritePrefix + (int)type);
        if (sprite != null && Image != null)
        {
            Image.sprite = sprite;
        }
    }

    public void Match()
    {
        throw new System.NotImplementedException();
    }



}
