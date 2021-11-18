using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Attackable
{
    // References
    PlayerMan pm;
    public override EntityMan em { get { return pm; } }

    public void SetParams(PlayerMan pm)
    {
        this.pm = pm;

        maxHealth = pm.playerInfo.health;
        health = maxHealth;

        base.SetParams();
    }
}