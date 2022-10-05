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
            move.MoveTowards(new Vector2(0, 0.01f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.MoveTowards(new Vector2(0, -0.01f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.MoveTowards(new Vector2(0.01f, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.MoveTowards(new Vector2(-0.01f, 0));
        }
    }
}
