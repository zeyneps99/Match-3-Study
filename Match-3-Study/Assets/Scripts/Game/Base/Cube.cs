using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : GameEntity
{
    public CubeTypes Type;


    private const string _spritePath = "Sprites/Cubes/";
    private const string _spritePrefix = "cube_";
    private Image _image;
    public void SetType(CubeTypes type)
    {
        Type = type;
        _image = GetComponent<Image>();
        var sprite = Resources.Load<Sprite>(_spritePath + _spritePrefix + (int)type);
        if (sprite != null && _image != null)
        {
            _image.sprite = sprite;
        }

    }

    

}
