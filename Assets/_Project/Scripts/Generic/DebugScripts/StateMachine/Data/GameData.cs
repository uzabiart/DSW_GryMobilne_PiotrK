using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public enum EGameState
{
    None = 0,
    Intro = 5,
    Menu = 10,
    Gameplay = 20
}

[CreateAssetMenu(menuName = "UMI/Game Data")]
public class GameData : ScriptableObject
{
    [SerializeField]
    public static GameData Instance;
    public PlayerData playerData;

    public static UserData UserData = new UserData();

    public EGameState CurrentGameState = EGameState.None;
    public EGameState PreviousGameState = EGameState.None;

    public async void Init()
    {
        Instance = this;
        await Task.Delay(10);
        ChangeGameState(EGameState.Intro);
    }

    public void ChangeGameState(EGameState newGameState)
    {
        CurrentGameState = newGameState;
        UIEvents.OnShowMessage?.Invoke(new PopupInfo($"new game state: {CurrentGameState.ToString()}"));
        GlobalEvents.OnGameplayStateChange?.Invoke();
        PreviousGameState = newGameState;
    }
}

[System.Serializable]
public class UserData
{
    public string userId;
}