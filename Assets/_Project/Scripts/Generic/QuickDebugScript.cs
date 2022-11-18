using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDebugScript : MonoBehaviour
{
    public int sscore;

    [System.Serializable]
    public class Wrapper<T>
    {
        public SerializedDictionary<string, T> items = new SerializedDictionary<string, T>();
    }

    [Button]
    public void SaveHighscore()
    {
        Wrapper<int> smthing = new Wrapper<int>();
        smthing.items.Add("123", 3);

        Debug.Log(JsonUtility.ToJson(smthing));

        string jsonData = JsonUtility.ToJson(this);
        Debug.Log(jsonData);
        PlayerPrefs.SetString("score", jsonData);
    }

    [Button]
    public void LoadHighScore()
    {
        Debug.Log(PlayerPrefs.GetString("score", ""));
        //score = JsonUtility.FromJson<ScoreClass>(PlayerPrefs.GetString("score", ""));
    }
}

[System.Serializable]
public class ScoreClass
{
    public string characterName;
    public int recentScore;
    public int highScore;
}

public class LevelDictionary
{
}

[System.Serializable]
public class Level
{
    public int something;
}