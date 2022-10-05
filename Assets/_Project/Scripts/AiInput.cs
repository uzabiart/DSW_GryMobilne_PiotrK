using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiInput : MonoBehaviour
{
    public Move move;
    public Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        move.MoveTowards(new Vector2(0, -0.01f));
    }
}