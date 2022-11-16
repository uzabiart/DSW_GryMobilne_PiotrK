using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class HitBox : Module
{
    public Health health;

    public Entity MyEntity()
    {
        return entity;
    }

    public Health GetHealth()
    {
        return health;
    }
}