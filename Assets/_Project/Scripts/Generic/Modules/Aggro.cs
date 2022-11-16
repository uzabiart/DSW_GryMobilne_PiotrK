using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Aggro : MonoBehaviour
{
    public GameObject excplanationMark;

    private void OnEnable()
    {
        UIEvents.OnShowMessage += ShowAggro;
    }
    private void OnDisable()
    {
        UIEvents.OnShowMessage -= ShowAggro;
    }

    async private void ShowAggro(PopupInfo info)
    {
        excplanationMark.SetActive(true);
        await Task.Delay(1000);
        excplanationMark.SetActive(false);
    }
}
