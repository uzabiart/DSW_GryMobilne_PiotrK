using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public Move move;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    void Update()
    {
        if (Input.GetKeyDown(up))
        {
            move.OnMove(new Vector2(0, 1f));
        }
        if (Input.GetKeyDown(down))
        {
            move.OnMove(new Vector2(0, -1f));
        }
        if (Input.GetKeyDown(right))
        {
            move.OnMove(new Vector2(1f, 0));
        }
        if (Input.GetKeyDown(left))
        {
            move.OnMove(new Vector2(-1f, 0));
        }
        if (Input.GetKeyDown(jump))
        {
            move.OnJump();
        }
    }
}
