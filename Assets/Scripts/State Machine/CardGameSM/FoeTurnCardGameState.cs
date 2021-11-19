using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FoeTurnCardGameState : CardGameState
{
    public static event Action FoeTurnBegan;
    public static event Action FoeTurnEnded;

    [SerializeField] float pauseDuration = 1.5f;

    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Enter");
        FoeTurnBegan?.Invoke();

        StartCoroutine(FoeThinkingRoutine(pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exit...");
        FoeTurnEnded?.Invoke();
    }

    IEnumerator FoeThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Enemy performs action");

        DecideNextState();
    }

    private void DecideNextState()
    {
        if (ServiceLocator.GetService<GameMan>().ProgressionMan.PlayerLoses)
        {
            StateMachine.ChangeState<LoseState>();
        }
        else
        {
            StateMachine.ChangeState<PlayerTurnCardGameState>();
        }
    }
}
