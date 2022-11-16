using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPatternExample : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
        }
    }
}

public interface ICommand
{
    public void Execute();
    public void Undo();
}