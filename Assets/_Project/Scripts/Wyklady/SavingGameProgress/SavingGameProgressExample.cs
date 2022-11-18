using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SavingGameProgressExample : MonoBehaviour
{
    public Text highscore;
    public static SavingPlayerData currentPlayer = new SavingPlayerData();

    private void Start()
    {
        Refresh();
    }
    public void Refresh()
    {
        highscore.text = $"HIGHSCORE:\n{currentPlayer.score}";
    }

    public void IncreaseHighScore()
    {
        currentPlayer.score++;
        Refresh();
    }
    public void SaveProgress()
    {
        GameplayEvents.OnSaveGame?.Invoke();
        PlayerSavedData.SavedPlayer = currentPlayer;
        Refresh();
    }
    public void LoadProgress()
    {
        currentPlayer = PlayerSavedData.SavedPlayer;
        GameplayEvents.OnLoadGame?.Invoke();
        Refresh();
    }
}

public class PlayerSavedData
{
    public static int PlayerHighscore
    {
        get
        {
            return PlayerPrefs.GetInt("highscore", 0);
        }
        set
        {
            PlayerPrefs.SetInt("highscore", value);
        }
    }

    public static int PlayerHighscoreSaveToFile
    {
        get
        {
            return int.Parse(File.ReadAllText($"{Application.persistentDataPath}/highscore.txt"));
        }
        set
        {
            File.WriteAllText($"{Application.persistentDataPath}/highscore.txt", value.ToString());
        }
    }

    public static SavingPlayerData SavedPlayer
    {
        get
        {
            return JsonUtility.FromJson<SavingPlayerData>(File.ReadAllText($"{Application.persistentDataPath}/player_data.json"));
        }
        set
        {
            Debug.Log($"Saved to: {Application.persistentDataPath}");
            File.WriteAllText($"{Application.persistentDataPath}/player_data.json", JsonUtility.ToJson(value));
        }
    }
}

[System.Serializable]
public class SavingPlayerData
{
    public string playerName;
    public int score;
    public int level;
    public int health;
    public Vector2 pos;
    public PlayerItem[] playerItems;
}

[System.Serializable]
public class PlayerItem
{
    public string itemName;
    public int level;
}