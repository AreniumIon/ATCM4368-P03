using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenMan : EntityMan
{
    public override void SetParams(EntityInfo entityInfo)
    {
        this.entityInfo = entityInfo;
    }

    /*
    public TokenInfo playerInfo
    {
        get => (PlayerInfo)entityInfo;
        set => SetParams(value);
    }
    */

    protected override void Die()
    {

    }
}
