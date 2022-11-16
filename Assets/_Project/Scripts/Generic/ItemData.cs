using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UMI/new Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite art;
    public int cost;
    public int id;
}