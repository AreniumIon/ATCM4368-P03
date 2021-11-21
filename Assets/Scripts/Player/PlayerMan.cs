using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMan : EntityMan
{
    public PlayerHealth PlayerHealth;
    public PlayerTokens PlayerTokens;

    public override void SetParams(EntityInfo entityInfo)
    {
        this.entityInfo = entityInfo;

        PlayerHealth.SetParams(this);
        PlayerTokens.SetParams(this);
    }

    public PlayerInfo playerInfo
    {
        get => (PlayerInfo)entityInfo;
        set => SetParams(value);
    }

    protected override void Die()
    {
        // Remove gameMan reference
        GameMan gameMan = ServiceLocator.GetService<GameMan>();
        if (gameMan.PlayerMan == this)
            gameMan.PlayerMan = null;
        base.Die();
    }
}
