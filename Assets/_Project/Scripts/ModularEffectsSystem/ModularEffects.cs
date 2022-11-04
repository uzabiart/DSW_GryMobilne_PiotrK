using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularEffects : SerializedMonoBehaviour
{
    public IEffect[] effects;

    [Button]
    public void Debugs()
    {
        foreach (IEffect effect in effects)
            effect.Execute();
    }
}

public interface IEffect
{
    public abstract void Execute();
}

[System.Serializable]
public class Heal : IEffect
{
    public int healAmount;

    public void Execute()
    {
        Debug.Log($"Heal effect: {healAmount}");
    }
}

[System.Serializable]
public class DamageEffect : IEffect
{
    public int damageValue;

    public void Execute()
    {
        Debug.Log($"Damage effect: {damageValue}");
    }
}

[System.Serializable]
public class JumpEffect : IEffect
{
    public int power;
    public int height;
    public string text;

    public void Execute()
    {
        Debug.Log($"Jump effect: {power}, {height}, {text}");
    }
}