using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTurnState : TokenGameState
{
    public static event Action PlayerTurnBegan;
    public static event Action PlayerTurnEnded;

    public static float AFTER_TURN_DELAY = 1f;

    int playerTurnCount = 0;
    public int PlayerTurnCount { get { return playerTurnCount; } }

    [SerializeField] int maxTokens = 3;

    public override void Enter()
    {
        Debug.Log("player turn enter");
        playerTurnCount += 1;

        CheckSpawnToken();

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
        StartCoroutine(AdvanceState());
    }

    private IEnumerator AdvanceState()
    {
        yield return new WaitForSeconds(AFTER_TURN_DELAY);

        // Check if foe exists
        if (ServiceLocator.GetService<GameMan>().FoeMan == null)
        {
            GameMan gameMan = ServiceLocator.GetService<GameMan>();

            if (gameMan.ProgressionMan.HasNextFoe())
                StateMachine.ChangeState<SetupBattleState>();
            else
                StateMachine.ChangeState<WinState>();
        }
        else
        {
            StateMachine.ChangeState<FoeTurnState>();
        }
    }

    void CheckSpawnToken()
    {
        PlayerMan playerMan = ServiceLocator.GetService<GameMan>().PlayerMan;

        if (playerMan.PlayerTokens.tokens.Count < maxTokens)
        {
            Debug.Log("Creating token");
            TokenConstructor.CreatePlayerToken();
        }
    }
}
