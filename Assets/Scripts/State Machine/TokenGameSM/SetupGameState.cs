using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetupGameState : TokenGameState
{
    [SerializeField] PlayerInfo playerInfo;

    bool activated = false;

    public override void Enter()
    {
        CreatePlayer();

        activated = false;
    }

    public override void Tick()
    {
        if (activated == false)
        {
            activated = true;
            StateMachine.ChangeState<SetupBattleState>();
        }
    }

    public override void Exit()
    {
        activated = false;
    }

    private void CreatePlayer()
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();
        GameUIMan gameUIMan = ServiceLocator.GetService<GameUIMan>();

        GameObject playerManObject = PlayerConstructor.CreatePlayer(playerInfo.playerID, gameUIMan.PlayerUI.canvasObj.transform);
        PlayerMan playerMan = playerManObject.GetComponent<PlayerMan>();

        gameMan.PlayerMan = playerMan;
        playerMan.SetParams((EntityInfo)playerInfo);
    }
}
