using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Module
{
    [SerializeField]
    private CollisionDetection detection;
    public HitBox hitBox;
    public int damage;

    protected void Awake()
    {
        base.Awake();
        detection = GetComponentInChildren<CollisionDetection>();
    }

    private void OnEnable()
    {
        detection.onCollision += AttackTarget;
    }
    private void OnDisable()
    {
        detection.onCollision -= AttackTarget;
    }

    public void AttackTarget(HitBox hitBox)
    {
        if (this.hitBox == hitBox) return;

        hitBox.health.TakeDamage(damage);
    }
}