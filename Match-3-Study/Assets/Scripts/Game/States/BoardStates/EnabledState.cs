using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledState : IBoardState
{
    public void Enter()
    {
        GameLogic.Instance?.EnableBoard(true);
    }

    public void Exit()
    {
       // throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
