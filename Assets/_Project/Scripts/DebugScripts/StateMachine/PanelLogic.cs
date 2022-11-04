using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLogic : MonoBehaviour
{
    public EGameState myGameState;

    private void OnEnable()
    {
        GlobalEvents.OnGameplayStateChange += ManageView;
    }
    private void OnDisable()
    {
        GlobalEvents.OnGameplayStateChange -= ManageView;
    }

    public void ManageView()
    {
        if (GameData.Instance.CurrentGameState != myGameState) transform.GetChild(0).gameObject.SetActive(false);
        else transform.GetChild(0).gameObject.SetActive(true);
    }
}
