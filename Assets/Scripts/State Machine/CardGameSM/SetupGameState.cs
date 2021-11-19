using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetupGameState : CardGameState
{
    [SerializeField] int startingTokenNumber = 10;
    [SerializeField] int numberOfPlayers = 2;

    bool activated = false;

    public override void Enter()
    {
        Debug.Log("Setup: ...Entering");
        Debug.Log("Creating " + numberOfPlayers + " players.");
        Debug.Log("Creating " + startingTokenNumber + " tokens.");
        activated = false;
    }

    public override void Tick()
    {
        if (activated == false)
        {
            activated = true;
            StateMachine.ChangeState<PlayerTurnCardGameState>();
        }
    }

    public override void Exit()
    {
        activated = false;
        Debug.Log("Setup: Exiting...");
    }
}
