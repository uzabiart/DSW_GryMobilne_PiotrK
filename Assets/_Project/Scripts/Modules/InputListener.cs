using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public Move move;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            move.MoveTo(new Vector2(0, 1f));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            move.MoveTo(new Vector2(0, -1f));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            move.MoveTo(new Vector2(1f, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            move.MoveTo(new Vector2(-1f, 0));
        }
    }
}
