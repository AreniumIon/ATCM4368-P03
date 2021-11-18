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

    public static GameObject CreatePlayer(PlayerID newPlayerID, Transform parent, Vector3 position)
    {
        GameObject newPlayer = GameObject.Instantiate(playerPrefab);

        // Transform
        TransformFunctions.SetTransform(newPlayer.transform, position);
        if (parent != null)
            newPlayer.transform.SetParent(parent);

        // Player
        PlayerMan pm = newPlayer.GetComponent<PlayerMan>();
        pm.SetParams(playerDict[newPlayerID]);

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