using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TokenMan : EntityMan
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI valueText;

    public override void SetParams(EntityInfo entityInfo)
    {
        this.entityInfo = entityInfo;

        icon.sprite = tokenInfo.sprite;
    }

    public TokenInfo tokenInfo
    {
        get => (TokenInfo)entityInfo;
        set => SetParams(value);
    }

    protected override void Die()
    {

    }
}
