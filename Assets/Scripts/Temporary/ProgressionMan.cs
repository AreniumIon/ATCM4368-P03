using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionMan : MonoBehaviour
{
    // Temporarily used to keep track of when player wants to win or lose the game. Referenced by buttons in GameScene.

    public static bool PlayerWins { get { return playerWins; } }
    static bool playerWins = false;

    public static bool PlayerLoses { get { return playerLoses; } }
    static bool playerLoses = false;

    public void SetPlayerWin()
    {
        playerWins = true;
    }

    public void SetPlayerLose()
    {
        playerLoses = true;
    }
}
