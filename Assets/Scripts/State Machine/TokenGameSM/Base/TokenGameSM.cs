using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenGameSM : StateMachine
{
    [SerializeField] InputController input;
    public InputController Input => input;

    private void Start()
    {
        ChangeState<SetupGameState>();
    }
}
