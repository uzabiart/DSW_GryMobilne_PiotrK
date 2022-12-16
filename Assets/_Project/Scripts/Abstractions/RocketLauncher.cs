using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : ItemS, ISight, IMagazine
{
    public override int damage => 20;

    public int zoomRange => 5;

    public int ammo { get => 3; set => ammo = value; }

    public void Relod()
    {
        ammo = 3;
        //reload code / animations etc
    }

    public void SpendAmmo()
    {
        ammo--;
    }

    public void ZoomIn()
    {
        Debug.Log("Rocket launcher zoom in logic");
    }
}

public interface IMagazine
{
    public int ammo { get; set; }

    public void Relod();
    public void SpendAmmo();
}