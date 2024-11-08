using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : ILifeComponent
{
    private Character selfCharacter;
    private float currentHealth;

    public float MaxHealth
    {
        get => 50f;
        protected set { return; }
    }
    public float Health
    {
        get => currentHealth;
        protected set
        {
            currentHealth = value;
            if (currentHealth > MaxHealth)
                currentHealth = MaxHealth;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                SetDeath();
            }
        }
    }

    public event Action<Character> OnCharacterDeath;

    public void SetDamage(float damage)
    {
        Health -= damage;
        Debug.Log("Get damage" + damage);
    }
    private void SetDeath()
    {
        OnCharacterDeath?.Invoke(selfCharacter);
        Debug.Log("I am ded :(");
    }

    public void Initialize(Character selfCharacter)
    {
        this.selfCharacter = selfCharacter;
    }
}
