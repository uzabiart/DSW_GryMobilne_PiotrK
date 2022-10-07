using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : Module
{
    private Transform movable;

    private void Start()
    {
        movable = entity.transform;
    }

    public void MoveTo(Vector2 moveTo)
    {
        movable.Translate(moveTo);
    }

    public void MoveTowards(Vector3 target)
    {
        float dist = Vector3.Distance(movable.position, target);
        movable.DOMove(target, dist);
    }
}