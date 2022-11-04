using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{


    public List<int> arr = new List<int>()
    {
        1,1,1,2,2,1,1,1,1,1,1,1,1
    };

    public List<int[]> arr2 = new List<int[]>()
    {
        new int[]{ 1,1,1,2 },
        new int[]{ 0,0,0,0 },
        new int[]{ 1,1,1,1 },
        new int[]{ 1,1,1,1 },
    };

    public List<Building> dictionary = new List<Building>();

    private void Start()
    {
        Debug.Log(arr2);
    }
}

public class Building
{
    public Building(int vin1, int vin2)
    {
        this.vin1 = vin1;
        this.vin2 = vin2;
    }

    public int vin1;
    public int vin2;
    public int value;
}