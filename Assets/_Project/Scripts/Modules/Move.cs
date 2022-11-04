using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : Module
{
    public SpriteRenderer sprite;
    private Transform movable;

    public void OnMove(Vector2 moveTo)
    {
        ActionRecorder.Record(new MoveAction(this, moveTo));
    }
    public void OnJump()
    {
        ActionRecorder.Record(new JumpAction(this));
    }
    public void OnChangeColor()
    {
        float randomAlpha = UnityEngine.Random.Range(0f, 1f);
        ActionRecorder.Record(new ChangeColorAction(this, randomAlpha));
    }

    public void MoveTo(Vector2 moveTo)
    {
        movable.Translate(moveTo);
    }

    public void Jump()
    {
        movable.DOPunchPosition(new Vector3(0, 0.5f, 0), 0.1f);
    }

    public void ChangeColor(float alpha)
    {
        sprite.DOFade(alpha, 0.1f);
    }

    private void Start()
    {
        movable = entity.transform;
    }
    public void MoveTowards(Vector3 target)
    {
        float dist = Vector3.Distance(movable.position, target);
        movable.DOMove(target, dist);
    }
}

public abstract class CommandBase
{
    public abstract void Undo();
    public abstract void Execute();
}

public class MoveAction : CommandBase
{
    public MoveAction(Move unit, Vector2 newPos)
    {
        this.unit = unit;
        this.newPos = newPos;
    }

    public Move unit;
    public Vector3 newPos;

    public override void Execute()
    {
        unit.MoveTo(newPos);
    }
    public override void Undo()
    {
        unit.MoveTo(newPos * -1);
    }
}

public class JumpAction : CommandBase
{
    public Move unit;

    public JumpAction(Move unit)
    {
        this.unit = unit;
    }

    public override void Execute()
    {
        unit.Jump();
    }
    public override void Undo()
    {
        unit.Jump();
    }
}

public class ChangeColorAction : CommandBase
{
    public ChangeColorAction(Move unit, float alpha)
    {
        this.unit = unit;
        this.alpha = alpha;
    }

    public Move unit;
    public float alpha;

    public override void Execute()
    {
        unit.ChangeColor(alpha);
    }

    public override void Undo()
    {
        unit.ChangeColor(alpha);
    }
}