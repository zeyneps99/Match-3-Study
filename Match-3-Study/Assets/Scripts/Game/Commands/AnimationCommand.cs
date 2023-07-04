using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCommand : Command
{
    private GameEntity gameEntity;
    public AnimationCommand(IEntity entity) : base(entity)
    {
        
    }
    public override void Execute()
    {
        
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }

   
}
