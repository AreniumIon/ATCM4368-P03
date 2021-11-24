using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FoeTurnState : TokenGameState
{
    public static event Action FoeTurnBegan;
    public static event Action FoeTurnEnded;

    [SerializeField] float pauseDuration = 1f;

    public override void Enter()
    {
        Debug.Log("foe turn enter");

        FoeTurnBegan?.Invoke();

        StartCoroutine(FoeThinkingRoutine(pauseDuration));
    }

    public override void Exit()
    {
        FoeTurnEnded?.Invoke();
    }

    IEnumerator FoeThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Enemy performs action");
        FoeAction();

        DecideNextState();
    }

    private void DecideNextState()
    {
        if (ServiceLocator.GetService<GameMan>().PlayerMan == null)
        {
            StateMachine.ChangeState<LoseState>();
        }
        else
        {
            StateMachine.ChangeState<PlayerTurnState>();
        }
    }

    private void FoeAction()
    {
        FoeMan foeMan = ServiceLocator.GetService<GameMan>().FoeMan;

        if (foeMan != null)
        {
            foeMan.FoeActions.DoAction();
        }
    }
}
