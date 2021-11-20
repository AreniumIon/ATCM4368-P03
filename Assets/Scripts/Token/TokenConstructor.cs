using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;
using System;

public static class TokenConstructor
{
    static GameObject tokenPrefab = Resources.Load<GameObject>("Prefabs/Token");

    /*
    static Dictionary<PlayerID, TokenInfo> tokenDict = new Dictionary<PlayerID, TokenInfo>()
    {
        {PlayerID.Normal, Resources.Load<PlayerInfo>("GameData/Data/PlayerInfo/Normal")},
    };

    public static PlayerInfo GetPlayerInfo(PlayerID playerID)
    {
        return tokenDict[playerID];
    }
    */

    /*
    public static GameObject CreateToken(PlayerID newPlayerID, Transform parent)
    {
        GameObject newPlayer = GameObject.Instantiate(tokenPrefab, parent, false);
        PlayerInfo playerInfo = tokenDict[newPlayerID];

        // Model
        GameObject modelPrefab = playerInfo.model;
        GameObject.Instantiate(modelPrefab, newPlayer.transform);

        // Player
        PlayerMan pm = newPlayer.GetComponent<PlayerMan>();
        pm.SetParams(playerInfo);

        // Health Bar
        EntityHealthBarConstructor.CreateHealthBar(pm.PlayerHealth, newPlayer.transform);

        // Events
        CreatePlayerEvent(pm);

        return newPlayer;
    }

    // Events
    public static event Action<PlayerMan> createPlayerEvent;
    public static void CreatePlayerEvent(PlayerMan newPlayer)
    {
        if (createPlayerEvent != null)
            createPlayerEvent(newPlayer);
    }

    public static void ClearEvents()
    {
        createPlayerEvent = null;
    }
    */
}
