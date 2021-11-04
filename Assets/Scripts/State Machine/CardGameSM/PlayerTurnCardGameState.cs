using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTurnCardGameState : CardGameState
{
    [SerializeField] TextMeshProUGUI playerTurnTextUI = null;

    int playerTurnCount = 0;

    public override void Enter()
    {
        Debug.Log("Player Turn: ...Entering");
        playerTurnTextUI.gameObject.SetActive(true);

        playerTurnCount++;
        playerTurnTextUI.text = "Player Turn: " + playerTurnCount.ToString();

        // hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Exit()
    {
        playerTurnTextUI.gameObject.SetActive(false);

        // unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;

        Debug.Log("Player Turn: Exiting...");
    }

    void OnPressedConfirm()
    {
        StateMachine.ChangeState<EnemyTurnCardGameState>();
    }
}
