using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardStateManager 
{
    private IBoardState currentState;

    public void SwitchState(IBoardState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }
}
