using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    [HideInInspector]
    public Entity entity;

    protected void Awake()
    {
        entity = GetComponentInParent<Entity>();
    }
}