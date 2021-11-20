using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTurnState : TokenGameState
{
    public static event Action PlayerTurnBegan;
    public static event Action PlayerTurnEnded;

    int playerTurnCount = 0;
    public int PlayerTurnCount { get { return playerTurnCount; } }

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


        AdvanceState();
    }

    void AdvanceState()
    {
        // Check if foe exists
        if (ServiceLocator.GetService<GameMan>().FoeMan == null)
        {
            StateMachine.ChangeState<WinState>();
        }
        else
        {
            StateMachine.ChangeState<FoeTurnState>();
        }
    }
}
