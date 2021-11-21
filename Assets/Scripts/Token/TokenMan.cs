using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static GameConstants;
using System;

public class TokenMan : EntityMan
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI amountText;

    int amount = 0;
    private int Amount
    { 
        get { return amount; }
        set { amount = value;  ChangeAmountEvent(); }
    }

    public event Action<int> changeAmountEvent; // amount
    private void ChangeAmountEvent()
    {
        changeAmountEvent?.Invoke(Amount);
    }


    public override void SetParams(EntityInfo entityInfo)
    {
        this.entityInfo = entityInfo;

        icon.sprite = tokenInfo.sprite;

        // Events
        changeAmountEvent += UpdateAmountText;

        // Initial values
        RandomizeAmount();
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


    private void RandomizeAmount()
    {
        Amount = UnityEngine.Random.Range(tokenInfo.minValue, tokenInfo.maxValue);
    }

    private void UpdateAmountText(int amount)
    {
        amountText.text = amount.ToString();
    }

    public void Activate()
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();

        // Create command
        Attackable target = GetTarget(tokenInfo.commandID);
        ICommand command = CommandConstructor.CreateCommand(tokenInfo.commandID, Amount, target);

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
