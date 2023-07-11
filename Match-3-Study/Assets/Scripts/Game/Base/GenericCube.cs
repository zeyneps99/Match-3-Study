using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericCube : Cube
{
    private Image Image;
    private const string _spritePath = "Sprites/Cubes/";
    private const string _spritePrefix = "cube_";
    private Color _color;
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

    private void SetParticleColor(ParticleSystem particleSystem)
    {
        if (particleSystem != null)
        {
            //todo
        }
    }

    public override void BlastAnimation()
    {

        SetParticleColor(BlastParticles);
        base.BlastAnimation();
    }


}
