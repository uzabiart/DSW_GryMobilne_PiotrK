using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : Module
{
    private Transform movable;
    public ActionRecorder actionRecorder = new ActionRecorder();

    public void OnMove(Vector2 moveTo)
    {
        ActionRecorder.Record(new MoveAction(this, moveTo));
    }
    public void OnJump()
    {
        ActionRecorder.Record(new JumpAction(this));
    }

    public void MoveTo(Vector2 moveTo)
    {
        movable.Translate(moveTo);
    }

    public void Jump()
    {
        movable.DOPunchPosition(new Vector3(0, 0.5f, 0), 0.1f);
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