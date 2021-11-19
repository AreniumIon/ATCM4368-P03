using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandStack : MonoBehaviour
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandHistory.Push(command);
    }
}
