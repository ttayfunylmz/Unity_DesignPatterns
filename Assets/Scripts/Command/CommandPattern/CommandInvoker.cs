using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    //Stack of command objects to "UNDO"
    private Stack<ICommand> undoStack = new Stack<ICommand>();
    //Stack of command objects to "REDO"
    private Stack<ICommand> redoStack = new Stack<ICommand>();

    //Execute the Command, add it to the undoStack and clear the redoStack.
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
        redoStack.Clear();
    }

    //Undo the action you made before, remove it from undoStack and add it to the redoStack.
    public void UndoCommand()
    {
        if(undoStack.Count > 0)
        {
            ICommand activeCommand = undoStack.Pop();
            redoStack.Push(activeCommand);
            activeCommand.Undo();
        }
        else
        {
            Debug.LogWarning("Nothing to UNDO!");
        }
    }

    //Execute the Redo action, add it to the undoStack and remove it from redoStack.
    public void RedoCommand()
    {
        if(redoStack.Count > 0)
        {
            ICommand activeCommand = redoStack.Pop();
            undoStack.Push(activeCommand);
            activeCommand.Execute();
        }
        else
        {
            Debug.LogWarning("Nothing to REDO!");
        }
    }
}
