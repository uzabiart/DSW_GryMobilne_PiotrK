using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase;
using System;
using UnityEngine.UI;

public class FirebaseDatabaseManager : MonoBehaviour
{
    DatabaseReference database;

    public Text infoDebugText;

    void Start()
    {
        // Get the root reference location of the database.
        database = FirebaseDatabase.DefaultInstance.RootReference;
    }

    private void OnEnable()
    {
        OnlineEvents.OnUserLogIn += OnUserLogin;

    }
    private void OnDisable()
    {
        OnlineEvents.OnUserLogIn -= OnUserLogin;
    }

    public async void OnUserLogin()
    {
        var getUserTask = database.Child($"users/{GameData.UserData.userId}").GetValueAsync();
        await getUserTask;

        if (!getUserTask.Result.Exists)
            CreateNewUser();
        else
            LoadData();
    }

    private void CreateNewUser()
    {
        database.Child("users").Child(GameData.UserData.userId).Child("uId").SetValueAsync(GameData.UserData.userId);
    }

    public async void LoadData()
    {
        DataSnapshot snapshotData = await database.Child("users").Child(GameData.UserData.userId).Child("playerData").GetValueAsync();
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(snapshotData.Value.ToString());
        GameData.Instance.playerData = playerData;
        Debug.Log("Data loaded");
        RefreshUI();
    }

    public async void SaveData()
    {
        string jsonData = JsonUtility.ToJson(GameData.Instance.playerData);
        await database.Child("users").Child(GameData.UserData.userId).Child("playerData").SetValueAsync(jsonData);
        Debug.Log("Data saved");
        RefreshUI();
    }

    public void RefreshUI()
    {
        infoDebugText.text = $"";
        infoDebugText.text += $"name: {GameData.Instance.playerData.playerName}\n";
        infoDebugText.text += $"health: {GameData.Instance.playerData.health}\n";
        infoDebugText.text += $"gold: {GameData.Instance.playerData.gold}\n";
        infoDebugText.text += $"armor: {GameData.Instance.playerData.armor}\n";
        infoDebugText.text += $"position: {GameData.Instance.playerData.position}\n";
        infoDebugText.text += $"ammo: {GameData.Instance.playerData.ammo}\n";
    }
}