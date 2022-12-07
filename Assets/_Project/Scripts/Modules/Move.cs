using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : Module
{
    private Transform movable;
    public float speed;
    public Health health;
    string animationId;
    bool killed = false;

    protected override void Awake()
    {
        base.Awake();
        animationId = $"{gameObject.GetInstanceID()}_animationmove";
    }

    private void Start()
    {
        health.onDestroy += StopAnimations;
        movable = entity.transform;
    }

    public void StopAnimations()
    {
        killed = true;
        DOTween.Kill(animationId);
    }

    public void MoveTo(Vector2 moveTo)
    {
        movable.Translate(moveTo);
    }

    public void MoveTowards(Vector3 target)
    {
        if (killed) return;
        float dist = Vector3.Distance(movable.position, target);
        movable.DOMove(target, dist * speed * Time.deltaTime).SetId(animationId);
    }
}