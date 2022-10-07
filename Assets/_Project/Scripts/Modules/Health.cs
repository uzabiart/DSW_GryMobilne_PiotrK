using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Module
{
    public int maxHealth;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"{entity.gameObject.name} took damage: {damage}");
        currentHealth -= damage;
        if (currentHealth <= 0) Destroy(entity.gameObject);
    }
    public void Heal(int heal)
    {
    }
}