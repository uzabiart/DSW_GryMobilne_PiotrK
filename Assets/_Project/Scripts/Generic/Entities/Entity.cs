using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    Module[] modules;

    private void Awake()
    {
        SetupModules();
    }

    private void SetupModules()
    {
        modules = GetComponentsInChildren<Module>();
    }

    public Module GetModule(Module mod)
    {
        foreach (Module m in modules)
        {
            if (mod.GetType() == m.GetType())
                return m;
        }

        return null;
    }
}
