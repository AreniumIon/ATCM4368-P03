using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetupBattleState : TokenGameState
{
    public static event Action SetupBattleBegan;
    public static event Action SetupBattleEnded;

    [SerializeField] int startingTokenNumber = 3;
    [SerializeField] float setupDuration = 1.5f;

    public override void Enter()
    {
        Debug.Log("setup battle state");

        SetupBattleBegan?.Invoke();

        StartCoroutine(SetupBattleRoutine(setupDuration));
    }

    public override void Exit()
    {
        SetupBattleEnded?.Invoke();
    }

    IEnumerator SetupBattleRoutine(float pauseDuration)
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();
        GameUIMan gameUIMan = ServiceLocator.GetService<GameUIMan>();

        yield return new WaitForSeconds(pauseDuration);

        gameMan.ProgressionMan.AdvanceBattle();

        CreateFoe();
        Debug.Log("Token1: " + gameMan.PlayerMan.PlayerTokens.tokens.Count);
        ClearTokens();
        Debug.Log("Token2: " + gameMan.PlayerMan.PlayerTokens.tokens.Count);
        SpawnTokens();
        Debug.Log("Token3: " + gameMan.PlayerMan.PlayerTokens.tokens.Count);
        DecideNextState();
    }

    private void DecideNextState()
    {
        StateMachine.ChangeState<PlayerTurnState>();
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
