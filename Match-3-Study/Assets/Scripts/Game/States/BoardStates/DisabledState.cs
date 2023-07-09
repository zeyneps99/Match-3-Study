using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DisabledState : IBoardState
{
    public void Enter()
    {
        GameLogic.Instance?.EnableBoard(false);
    }

    public void Exit()
    {
      //  throw new System.NotImplementedException();
    }

    public void Update()
    {
      //  throw new System.NotImplementedException();
    }
}
