using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCommand : Command
{
    protected Vector2 _touchPosition;
    public TapCommand(IEntity entity, Vector2 touchPosition) : base(entity)
    {
        _touchPosition = touchPosition;
    }
    public override void Execute()
    {
        if (GameLogic.Instance != null && _entity.gameObject.TryGetComponent(out Cube cube))
        {
            GameLogic.Instance.CheckForMatches(cube);
        }
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }



}
