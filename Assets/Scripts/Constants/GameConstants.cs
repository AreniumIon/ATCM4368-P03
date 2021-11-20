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
        Token = 3,
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

    public enum CommandID
    {
        Attack = 0,
        Defend = 1,
        Heal = 2,
    }

}
