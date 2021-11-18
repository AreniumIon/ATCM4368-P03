using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTurnUI : MonoBehaviour
{
    [SerializeField] GameObject canvasObj = null;
    [SerializeField] TextMeshProUGUI playerTurnTextUI = null;

    [SerializeField] PlayerTurnCardGameState playerTurnState;

    private void OnEnable()
    {
        PlayerTurnCardGameState.PlayerTurnBegan += OnPlayerTurnBegan;
        PlayerTurnCardGameState.PlayerTurnEnded += OnPlayerTurnEnded;
    }

    private void OnDisable()
    {
        PlayerTurnCardGameState.PlayerTurnBegan -= OnPlayerTurnBegan;
        PlayerTurnCardGameState.PlayerTurnEnded -= OnPlayerTurnEnded;
    }

    private void OnPlayerTurnBegan()
    {
        canvasObj.SetActive(true);
        playerTurnTextUI.text = "Player Turn: " + playerTurnState.PlayerTurnCount;
    }

    private void OnPlayerTurnEnded()
    {
        canvasObj.SetActive(false);
    }
}
