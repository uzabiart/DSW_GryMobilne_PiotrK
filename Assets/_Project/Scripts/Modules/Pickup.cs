using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Module
{
    public CollisionDetection detection;

    private void OnEnable()
    {
        detection.onCollision += PickupIfAble;
    }
    private void OnDisable()
    {
        detection.onCollision -= PickupIfAble;
    }

    private void PickupIfAble(HitBox hitBox)
    {
        //if (this.hitBox == hitBox) return;

        Debug.Log(hitBox.entity.name);
        Module pickup = hitBox.entity.GetModule(new Pickable());
        if (pickup == null) return;
        Pickable p = (Pickable)pickup;
        p.OnPickup();
    }
}