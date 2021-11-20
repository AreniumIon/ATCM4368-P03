using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;
using System;

public static class PlayerConstructor
{
    static GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Player");

    static Dictionary<PlayerID, PlayerInfo> playerDict = new Dictionary<PlayerID, PlayerInfo>()
    {
        {PlayerID.Normal, Resources.Load<PlayerInfo>("GameData/Data/PlayerInfo/Normal")},
    };

    public static PlayerInfo GetPlayerInfo(PlayerID playerID)
    {
        return playerDict[playerID];
    }


    public static GameObject CreatePlayer(PlayerID newPlayerID, Transform parent)
    {
        GameObject newPlayer = GameObject.Instantiate(playerPrefab, parent, false);
        PlayerInfo playerInfo = playerDict[newPlayerID];

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
}