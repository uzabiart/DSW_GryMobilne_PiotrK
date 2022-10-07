using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public Move move;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            move.MoveTo(new Vector2(0, 0.01f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.MoveTo(new Vector2(0, -0.01f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.MoveTo(new Vector2(0.01f, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.MoveTo(new Vector2(-0.01f, 0));
        }
    }
}
