using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    public CubeTypes Type;
    public Image Image;
    private Vector2Int _gridPos;

    private const string _cubePath = "Sprites/Cubes/cube_";
    public void Init(CubeTypes type)
    {
        this.Type = type;
        SetSprite(type);
    }

    private void SetSprite(CubeTypes type)
    {
        Sprite sprite = Resources.Load<Sprite>(_cubePath + (int) type);
        if (sprite != null && Image != null)
        {
            Image.sprite = sprite;
        }
    }


}
