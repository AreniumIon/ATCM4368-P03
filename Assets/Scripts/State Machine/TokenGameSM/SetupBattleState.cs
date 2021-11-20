using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBattleState : TokenGameState
{
    [SerializeField] int startingTokenNumber = 3;
    [SerializeField] FoeInfo foeInfo;

    bool activated = false;

    public override void Enter()
    {
        CreateFoe();
        SpawnTokens();

        activated = false;
    }

    public override void Tick()
    {
        if (activated == false)
        {
            activated = true;
            StateMachine.ChangeState<PlayerTurnState>();
        }
    }

    public override void Exit()
    {
        activated = false;
    }

    private void CreateFoe()
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();
        GameUIMan gameUIMan = ServiceLocator.GetService<GameUIMan>();

        GameObject foeManObject = FoeConstructor.CreateFoe(foeInfo.foeID, gameUIMan.FoeUI.canvasObj.transform);
        FoeMan foeMan = foeManObject.GetComponent<FoeMan>();

        gameMan.FoeMan = foeMan;
    }

    private void SpawnTokens()
    {
        for (int i = 0; i < startingTokenNumber; i++)
        {
            TokenConstructor.CreatePlayerToken();
        }
    }
}
