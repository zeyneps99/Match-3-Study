using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCommand : Command
{
    protected Vector2 _dragDirection;
    public DragCommand(IEntity entity, Vector2 dragDirection) : base(entity)
    {
        _dragDirection = dragDirection;
    }
    public override void Execute()
    {
        Debug.Log("drag registered : " + _dragDirection);
        // throw new System.NotImplementedException();
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }

}
