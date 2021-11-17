using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Attackable : MonoBehaviour
{
    // Can make public if needed
    public abstract EntityMan em { get; }

    // Health
    public event Action<float, float> changeHealthEvent; // Health, MaxHealth
    public void ChangeHealthEvent()
    {
        changeHealthEvent?.Invoke(health, maxHealth);
        CheckDeath();
    }

    protected float maxHealth = 10f;
    public virtual float MaxHealth
    {
        get { return maxHealth; }
        set { ClampMaxHealth(value); ChangeHealthEvent(); }
    }

    protected float health = 10f;
    public virtual float Health
    {
        get { return health; }
        set { ClampHealth(value); ChangeHealthEvent(); }
    }

    protected void ClampMaxHealth(float value) { maxHealth = MathFunctions.Clamp(value, 1); ClampHealth(health); }
    protected void ClampHealth(float value) { health = MathFunctions.Clamp(value, 0, maxHealth); }


    protected void CheckDeath()
    {
        if (health <= 0)
            em.DeathEvent();
    }

    // Startup
    protected void SetParams()
    {
        ChangeHealthEvent();
    }
}
