using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentPoints;

    private void OnEnable()
    {
        GlobalEvents.OnSpacebarHit += AddPoint;
    }
    private void OnDisable()
    {
        GlobalEvents.OnSpacebarHit -= AddPoint;
    }

    public void AddPoint()
    {
        if (GameData.Instance.CurrentGameState != EGameState.Gameplay) return;

        currentPoints++;
    }
}