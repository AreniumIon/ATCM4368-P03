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

        maxHealth = fm.foeInfo.health;
        health = maxHealth;

        base.SetParams();
    }
}
