using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Attackable : MonoBehaviour
{
    // Can make public if needed
    public abstract EntityMan em { get; }

    // Health
    public event Action<int, int> changeHealthEvent; // Health, MaxHealth
    private void ChangeHealthEvent()
    {
        changeHealthEvent?.Invoke(health, maxHealth);
        CheckDeath();
    }

    private int maxHealth = 10;
    public virtual int MaxHealth
    {
        get { return maxHealth; }
        protected set { ClampMaxHealth(value); ChangeHealthEvent(); }
    }

    private int health = 10;
    public virtual int Health
    {
        get { return health; }
        protected set { ClampHealth(value); ChangeHealthEvent(); }
    }

    private void ClampMaxHealth(int value) { maxHealth = MathFunctions.Clamp(value, 1); ClampHealth(health); }
    private void ClampHealth(int value) { health = MathFunctions.Clamp(value, 0, maxHealth); }

    private void CheckDeath()
    {
        if (health <= 0)
            em.DeathEvent();
    }

    // Block
    public event Action<int> changeBlockEvent; // Block
    private void ChangeBlockEvent()
    {
        changeBlockEvent?.Invoke(block);
    }

    private int block = 0;
    public virtual int Block
    {
        get { return block; }
        private set { ClampBlock(value); ChangeBlockEvent(); }
    }

    private void ClampBlock(int value) { block = MathFunctions.Clamp(value, 0); }

    // Startup
    protected void SetParams()
    {
        ChangeHealthEvent();
    }

    // Methods
    public void TakeDamage(int amount)
    {
        Debug.Assert(amount >= 0, "TakeDamage must receive a positive amount");

        int blockDamage = Mathf.Min(amount, Block);
        int healthDamage = amount - blockDamage;

        if (blockDamage > 0)
        {
            Block -= blockDamage;
        }
        if (healthDamage > 0)
        {
            Health -= healthDamage;
        }
    }

    public void Heal(int amount)
    {
        Health += amount;
    }

    public void Defend(int amount)
    {
        Block += amount;
    }

    public void FullHeal()
    {
        Health = MaxHealth;
    }

    public void ClearBlock()
    {
        Block = 0;
    }
}
