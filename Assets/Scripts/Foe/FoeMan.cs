using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public class FoeMan : EntityMan
{
    public FoeActionIndicator FoeActionIndicator;

    public FoeHealth FoeHealth;
    public FoeActions FoeActions;

    public override void SetParams(EntityInfo entityInfo)
    {
        this.entityInfo = entityInfo;

        FoeActionIndicator.SetParams(this);

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
