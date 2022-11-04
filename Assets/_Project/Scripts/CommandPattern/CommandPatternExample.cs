using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPatternExample : MonoBehaviour
{
    ActionRecorder actionRecorder;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            JumpAction newS = new JumpAction();
            actionRecorder.Record(newS);
        }
    }
}

public class ActionRecorder
{
    public List<ICommand> allActions = new List<ICommand>();

    public void Record(ICommand action)
    {
    }
    public void Undo(ICommand action)
    {
    }
}

public interface ICommand
{
    public void Execute();
    public void Undo();
}

public class JumpAction : ICommand
{
    public void Execute()
    {
        Debug.Log("Jump Action");
    }
    public void Undo()
    {
        Debug.Log("Undo Jump action");
    }
}

public class MoveAction : ICommand
{
    public void Execute()
    {
    }
    public void Undo()
    {
    }
}