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
        Attackable target = GetTarget(tokenInfo.commandID);
        ICommand command = CommandConstructor.CreateCommand(tokenInfo.commandID, 5, target);

        // Execute
        gameMan.CommandStack.ExecuteCommand(command);

        // Remove Token
        DeathEvent();

        // Finish turn
        InputController inputController = gameMan.InputController;
        inputController.InvokeConfirm();
    }

    private Attackable GetTarget(CommandID commandID)
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();

        switch (commandID)
        {
            default:
            case CommandID.Attack:
                return gameMan.FoeMan.FoeHealth;
            case CommandID.Defend:
                return gameMan.PlayerMan.PlayerHealth;
            case CommandID.Heal:
                return gameMan.PlayerMan.PlayerHealth;
        }
    }
}
