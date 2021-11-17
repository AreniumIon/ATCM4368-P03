using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Attackable
{

    [SerializeField] float startHealth = 10f;

    // References
    PlayerMan pm;
    public override EntityMan em { get { return pm; } }

    public void SetParams(PlayerMan pm)
    {
        this.pm = pm;

        maxHealth = startHealth;
        health = maxHealth;

        base.SetParams();
    }
}