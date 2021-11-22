using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBattleState : TokenGameState
{
    [SerializeField] int startingTokenNumber = 3;
    [SerializeField] float setupDuration = 1.5f;

    bool activated = false;

    public override void Enter()
    {
        Debug.Log("setup battle state");

        StartCoroutine(SetupBattleRoutine(setupDuration));

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

    IEnumerator SetupBattleRoutine(float pauseDuration)
    {
        yield return new WaitForSeconds(pauseDuration);

        GameMan gameMan = ServiceLocator.GetService<GameMan>();
        gameMan.ProgressionMan.AdvanceBattle();

        CreateFoe();
        ClearTokens();
        SpawnTokens();
    }

    private void CreateFoe()
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();
        GameUIMan gameUIMan = ServiceLocator.GetService<GameUIMan>();

        GameObject foeManObject = FoeConstructor.CreateFoe(gameMan.ProgressionMan.GetCurrentFoe().foeID, gameUIMan.FoeUI.canvasObj.transform);
        FoeMan foeMan = foeManObject.GetComponent<FoeMan>();

        gameMan.FoeMan = foeMan;
    }

    private void ClearTokens()
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();
        PlayerTokens playerTokens = gameMan.PlayerMan.PlayerTokens;
        playerTokens.DestroyTokens();
    }

    private void SpawnTokens()
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();
        PlayerTokens playerTokens = gameMan.PlayerMan.PlayerTokens;
        while (playerTokens.tokens.Count < startingTokenNumber)
        {
            TokenConstructor.CreatePlayerToken();
        }
    }
}
