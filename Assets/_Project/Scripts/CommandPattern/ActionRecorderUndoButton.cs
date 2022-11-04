using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRecorderUndoButton : MonoBehaviour
{
    public void OnClick()
    {
        ActionRecorder.Undo();
    }
}