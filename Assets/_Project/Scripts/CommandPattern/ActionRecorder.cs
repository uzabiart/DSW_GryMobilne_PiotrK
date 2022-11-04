using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRecorder
{
    public static List<CommandBase> allActions = new List<CommandBase>();

    public static void Record(CommandBase action)
    {
        action.Execute();
        allActions.Add(action);
    }
    public static void Undo()
    {
        if (allActions.Count == 0) { Debug.Log("No more actions to undo"); return; }
        allActions[allActions.Count - 1].Undo();
        allActions.RemoveAt(allActions.Count - 1);
    }
}