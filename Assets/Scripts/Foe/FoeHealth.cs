using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeHealth : Attackable
{
    // References
    FoeMan fm;
    public override EntityMan em { get { return fm; } }

    public void SetParams(FoeMan fm)
    {
        this.fm = fm;

        // Values
        MaxHealth = fm.foeInfo.health;
        Health = MaxHealth;

        // Events
        FoeTurnState.FoeTurnBegan += ClearBlock;

        base.SetParams();
    }
}
