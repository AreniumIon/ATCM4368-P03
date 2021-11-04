using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTurnCardGameState : CardGameState
{
    public static event Action PlayerTurnBegan;
    public static event Action PlayerTurnEnded;

    static int playerTurnCount = 0;
    public static int PlayerTurnCount { get { return playerTurnCount; } }

    public override void Enter()
    {
        Debug.Log("Player Turn: ...Entering");
        playerTurnCount++;
        PlayerTurnBegan?.Invoke();

        // hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Exit()
    {
        // unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;

        Debug.Log("Player Turn: Exiting...");
        PlayerTurnEnded?.Invoke();
    }

    void OnPressedConfirm()
    {
        if (ProgressionMan.PlayerWins)
        {
            StateMachine.ChangeState<WinState>();
        }
        else
        {
            StateMachine.ChangeState<EnemyTurnCardGameState>();
        }
    }
}
