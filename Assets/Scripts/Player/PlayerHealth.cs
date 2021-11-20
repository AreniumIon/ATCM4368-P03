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

        // Values
        MaxHealth = pm.playerInfo.health;
        Health = MaxHealth;

        // Events
        PlayerTurnState.PlayerTurnBegan += ClearBlock;

        base.SetParams();
    }
}