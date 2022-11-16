using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Module
{
    public ItemData item;

    public void OnPickup()
    {
        GameplayEvents.OnItemPickup?.Invoke(item);
        Destroy(entity.gameObject);
    }
}