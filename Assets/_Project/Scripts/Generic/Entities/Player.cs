using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private void OnEnable()
    {
        GameplayEvents.OnSaveGame += SavePlayer;
        GameplayEvents.OnLoadGame += LoadPlayer;
    }
    private void OnDisable()
    {
        GameplayEvents.OnSaveGame -= SavePlayer;
        GameplayEvents.OnLoadGame -= LoadPlayer;
    }

    private void LoadPlayer()
    {
        Health health = (Health)GetModule(new Health());
        health.currentHealth = PlayerSavedData.SavedPlayer.health;
        transform.position = PlayerSavedData.SavedPlayer.pos;
    }

    private void SavePlayer()
    {
        Health health = (Health)GetModule(new Health());
        SavingGameProgressExample.currentPlayer.health = health.currentHealth;
        SavingGameProgressExample.currentPlayer.pos = transform.position;
        health.UpdateView();
        PlayerSavedData.SavedPlayer = SavingGameProgressExample.currentPlayer;
    }
}