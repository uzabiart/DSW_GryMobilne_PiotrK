using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRecorderUndoButton : MonoBehaviour
{
    public void UndoClick()
    {
        ActionRecorder.Undo();
    }

    public void ReplayClick()
    {
        ActionRecorder.Replay();
    }
}