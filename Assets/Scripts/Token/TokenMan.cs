using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static GameConstants;

public class TokenMan : EntityMan
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI valueText;

    public ICommand command;

    public override void SetParams(EntityInfo entityInfo)
    {
        this.entityInfo = entityInfo;

        icon.sprite = tokenInfo.sprite;
    }

    public TokenInfo tokenInfo
    {
        get => (TokenInfo)entityInfo;
        set => SetParams(value);
    }

    protected override void Die()
    {
        base.Die();
    }

    public void Activate()
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();

        // Create command
        Attackable target = GetTarget(tokenInfo.tokenID);
        ICommand command = CommandConstructor.CreateCommand(tokenInfo.tokenID, 5, target);

        // Execute
        gameMan.CommandStack.ExecuteCommand(command);

        // Remove Token
        DeathEvent();

        // Finish turn
        InputController inputController = gameMan.InputController;
        inputController.InvokeConfirm();
    }

    private Attackable GetTarget(TokenID tokenID)
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();

        switch (tokenID)
        {
            default:
            case TokenID.Attack:
                return gameMan.FoeMan.FoeHealth;
            case TokenID.Defend:
                return gameMan.PlayerMan.PlayerHealth;
            case TokenID.Heal:
                return gameMan.PlayerMan.PlayerHealth;
        }
    }
}
