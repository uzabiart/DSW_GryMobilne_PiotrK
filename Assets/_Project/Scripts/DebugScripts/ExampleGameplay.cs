using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleGameplay : MonoBehaviour
{
    public int addedExp = 4;
    public Image fillBar;

    public void AddExp()
    {
        UIEvents.OnShowMessage?.Invoke(new PopupInfo("Add 4 EXP 2", 2f));
    }

    public void ShowRandomMessage()
    {
        UIEvents.OnShowMessage?.Invoke(new PopupInfo("Random message 2", 2f));
    }
}