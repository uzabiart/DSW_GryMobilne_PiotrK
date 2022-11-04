using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionRecorder
{
    public static List<CommandBase> allActions = new List<CommandBase>();
    public static List<CommandBase> backupActions = new List<CommandBase>();

    public static void Record(CommandBase action)
    {
        action.Execute();
        allActions.Add(action);
        backupActions.Clear();
    }
    public static void Undo()
    {
        if (allActions.Count == 0)
        {
            Debug.Log("No more actions to undo"); return;
        }

        allActions[allActions.Count - 1].Undo();
        backupActions.Add(allActions[allActions.Count - 1]);
        allActions.RemoveAt(allActions.Count - 1);
    }
    public async static void Replay()
    {
        for (int i = backupActions.Count - 1; i >= 0; i--)
        {
            await Task.Delay(100);
            backupActions[i].Execute();
            allActions.Add(backupActions[i]);
        }
        backupActions.Clear();
    }
}