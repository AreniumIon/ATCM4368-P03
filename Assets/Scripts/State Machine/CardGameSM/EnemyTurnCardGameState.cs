using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTurnCardGameState : CardGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] float pauseDuration = 1.5f;

    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exit...");
        EnemyTurnEnded?.Invoke();
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
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
