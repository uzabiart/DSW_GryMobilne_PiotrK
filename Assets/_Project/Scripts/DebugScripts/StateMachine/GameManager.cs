using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        GlobalEvents.OnSpacebarHit += SpacebarHit;
    }
    private void OnDisable()
    {
        GlobalEvents.OnSpacebarHit -= SpacebarHit;
    }

    public void SpacebarHit()
    {
        // logik
    }
}