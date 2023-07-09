using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Cube : Entity, IMatchable, IAnimatable
{

    public CubeTypes Type;
    public bool IsVisited;
    public Vector2Int Position;


    [SerializeField] ParticleSystem BlastParticles;
    [SerializeField] ParticleSystem DropParticles;
   

    

    public virtual void Match()
    {
        Position = Vector2Int.down;
        BlastAnimation();
    }

    public void Enable(bool isEnable)
    {
        if(TryGetComponent(out EventTrigger eventTrigger))
        {
            eventTrigger.enabled = isEnable;
        }

        if (TryGetComponent(out LayoutElement layoutElement))
        {
            layoutElement.ignoreLayout = !isEnable;
        }
    }

    public virtual void BlastAnimation()
    {
        BlastParticles?.Play();
    }

    public virtual void DropAnimation()
    {
        DropParticles?.Play();
    }

    public virtual void FallAnimation()
    {
    }
}
