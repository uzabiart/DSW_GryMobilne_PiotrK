using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPanelDebug : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI health;
    public TextMeshProUGUI gold;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI position;
    public TextMeshProUGUI ammo;

    private void OnEnable()
    {
        UIEvents.OnUIRefresh += RefreshUI;
    }
    private void OnDisable()
    {
        UIEvents.OnUIRefresh -= RefreshUI;
    }

    private void RefreshUI()
    {
        playerName.text = $"PlayerName: {GameData.Instance.playerData.playerName}";
        health.text = $"Health: {GameData.Instance.playerData.health.ToString()}";
        gold.text = $"Gold: {GameData.Instance.playerData.gold.ToString()}";
        armor.text = $"Armor: {GameData.Instance.playerData.armor.ToString()}";
        position.text = $"Position: x: {GameData.Instance.playerData.position.x.ToString()}, y: {GameData.Instance.playerData.position.y.ToString()}";
        ammo.text = $"Ammo: {GameData.Instance.playerData.ammo.ToString()}";
    }
}