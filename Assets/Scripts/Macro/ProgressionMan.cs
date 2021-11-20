using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionMan : MonoBehaviour
{
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
