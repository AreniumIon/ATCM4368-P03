using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionMan : MonoBehaviour
{
    // Temporarily used to keep track of when player wants to win or lose the game. Referenced by buttons in GameScene.
    public static ProgressionMan i;

    private void Awake()
    {
        i = this;
    }

    public bool PlayerWins { get { return playerWins; } }
    bool playerWins = false;

    public bool PlayerLoses { get { return playerLoses; } }
    bool playerLoses = false;

    public void SetPlayerWin()
    {
        playerWins = true;
    }

    public void SetPlayerLose()
    {
        playerLoses = true;
    }
}
