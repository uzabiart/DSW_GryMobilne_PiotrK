using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform player;

    public void MoveTowards(Vector2 moveTo)
    {
        player.Translate(moveTo);
    }
}