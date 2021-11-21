using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public class FoeMan : EntityMan
{
    public FoeHealth FoeHealth;
    public FoeActions FoeActions;

    public override void SetParams(EntityInfo entityInfo)
    {
        this.entityInfo = entityInfo;

        FoeHealth.SetParams(this);
        FoeActions.SetParams(this);
    }

    public FoeInfo foeInfo
    {
        get => (FoeInfo)entityInfo;
        set => SetParams(value);
    }

    protected override void Die()
    {
        base.Die();
    }
}
