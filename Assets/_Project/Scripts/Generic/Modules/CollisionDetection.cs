using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CollisionDetection : Module
{
    public Action<HitBox> onCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Collision: {collision.gameObject.name}");

        HitBox hitBox = collision.GetComponent<HitBox>();
        if (hitBox == null) return;

        onCollision?.Invoke(hitBox);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}