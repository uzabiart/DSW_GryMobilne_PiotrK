using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon, ISight
{
    public override int damage { get => 1; }

    public int zoomRange => 2;

    public void ZoomIn()
    {
        Debug.Log("Pistol zoom in logic");
    }
}