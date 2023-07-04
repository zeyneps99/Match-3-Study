using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{
    private Command _currentCommand;

    public void ExecuteCommand(Command command)
    {
        _currentCommand.Execute();
        _currentCommand = command;
    }

    public void UndoCommand()
    {
        if (_currentCommand == null)
        {
            return;
        }
        _currentCommand.Undo();
        _currentCommand = null;
    }
}
