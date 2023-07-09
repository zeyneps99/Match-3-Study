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
       // Position = Vector2Int.down;

        //Animate();
    }

    public void Enable(bool isEnable)
    {
        if(TryGetComponent(out EventTrigger eventTrigger))
        {
            eventTrigger.enabled = isEnable;
        }

        //if (TryGetComponent(out LayoutElement layoutElement))
        //{
        //    layoutElement.ignoreLayout = !isEnable;
        //}
    }


}
