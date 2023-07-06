using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCommand : Command
{
    protected Vector2 _touchPosition;
    public TouchCommand(IEntity entity, Vector2 touchPosition) : base(entity)
    {
        _touchPosition = touchPosition;
    }
    public override void Execute()
    {
        Debug.Log("touch registered");
       // throw new System.NotImplementedException();
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }

    
}
