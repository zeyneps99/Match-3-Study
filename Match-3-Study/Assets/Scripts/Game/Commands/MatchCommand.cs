using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchCommand : Command
{
    public MatchCommand(IEntity entity) : base(entity) { }
    public override void Execute()
    {
    }

    public override void Undo()
    {

    }


}
