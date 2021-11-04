using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoseState : CardGameState
{
    public static event Action LoseBegan;
    public static event Action LoseEnded;

    public override void Enter()
    {
        Debug.Log("Lose: ...Entering");
        LoseBegan?.Invoke();
    }

    public override void Exit()
    {
        Debug.Log("Lose: Exiting...");
        LoseEnded?.Invoke();
    }
}
