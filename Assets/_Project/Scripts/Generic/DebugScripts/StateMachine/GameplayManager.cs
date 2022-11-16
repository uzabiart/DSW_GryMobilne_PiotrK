using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GlobalEvents.OnSpacebarHit?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            GameData.Instance.ChangeGameState(EGameState.Menu);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GameData.Instance.ChangeGameState(EGameState.Gameplay);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            UIEvents.OnShowMessage?.Invoke(new PopupInfo($"Updating playerInfo"));
            UIEvents.OnUIRefresh?.Invoke();
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public int health;
    public int gold;
    public int armor;
    public string playerName;
    public Vector2 position;
    public int ammo;
}