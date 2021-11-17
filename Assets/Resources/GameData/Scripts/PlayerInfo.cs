using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

[CreateAssetMenu(fileName = "New PlayerInfo", menuName = "EntityInfo/PlayerInfo")]
public class PlayerInfo : EntityInfo
{
    public PlayerInfo()
    {
        entityType = EntityType.Player;
    }

    public PlayerID playerID;
}