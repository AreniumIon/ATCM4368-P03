using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstants
{
    // Enums
    public enum EntityType
    {
        Entity = 0,
        Player = 1,
        Foe = 2,
    }

    public enum PlayerID
    { 
        Normal = 0,
    }

    public enum FoeID
    { 
        Spikeder = 0,
        Hambiter = 1,
        Venus_Fly_Trap = 2,
    }

    // Values
    public static Vector3 PLAYER_POS = new Vector3(-4, -1, -10);
    public static Vector3 FOE_POS = new Vector3(4, -1, -10);

}
