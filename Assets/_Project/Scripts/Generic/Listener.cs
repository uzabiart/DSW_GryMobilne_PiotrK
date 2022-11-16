using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    private void OnEnable()
    {
        GlobalEvents.OnEnable += Response;
    }
    private void OnDisable()
    {
        GlobalEvents.OnEnable -= Response;
    }

    public void Response()
    {
        Debug.Log("OnEnable");
    }
}