using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

[CreateAssetMenu(fileName = "New TokenInfo", menuName = "EntityInfo/TokenInfo")]
public class TokenInfo : EntityInfo
{
    public TokenInfo()
    {
        entityType = EntityType.Token;
    }

    public TokenID tokenID;
    public Sprite sprite;

    public int minValue = 1;
    public int maxValue = 10;
}
