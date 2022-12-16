using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizationDebug : MonoBehaviour
{
    Transform tr;

    private void Awake()
    {
        tr = transform;
    }

    private void Update()
    {
        transform.Translate(new Vector3(1, 0));
    }

    private void FixedUpdate()
    {
    }
}
