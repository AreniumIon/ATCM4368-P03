using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EntityMan : MonoBehaviour
{
    public EntityInfo entityInfo;

    public abstract void SetParams(EntityInfo entityInfo);

    // Death
    private bool hasDied = false;

    public event Action<EntityMan> deathEvent;
    public virtual void DeathEvent()
    {
        if (!hasDied)
        {
            hasDied = true;
            deathEvent?.Invoke(this);
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
