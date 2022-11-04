using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract int damage { get; }

    public virtual void TestShot()
    {
        Debug.Log($"Damage dealt: {damage}");
    }
}
