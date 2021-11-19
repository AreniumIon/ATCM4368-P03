using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TokenGameSM))]
public class TokenGameState : State
{
    protected TokenGameSM StateMachine { get; private set; }

    private void Awake()
    {
        StateMachine = GetComponent<TokenGameSM>();
    }
}
