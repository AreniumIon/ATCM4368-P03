using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WinState : CardGameState
{
    public static event Action WinBegan;
    public static event Action WinEnded;

    public override void Enter()
    {
        Debug.Log("Lose: ...Entering");
        WinBegan?.Invoke();
    }

    public override void Exit()
    {
        Debug.Log("Lose: Exiting...");
        WinEnded?.Invoke();
    }
}
