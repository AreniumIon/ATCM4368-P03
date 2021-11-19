using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTurnUI : MonoBehaviour
{
    [SerializeField] GameObject canvasObj = null;
    [SerializeField] TextMeshProUGUI playerTurnTextUI = null;

    private void OnEnable()
    {
        PlayerTurnState.PlayerTurnBegan += OnPlayerTurnBegan;
        PlayerTurnState.PlayerTurnEnded += OnPlayerTurnEnded;
    }

    private void OnDisable()
    {
        PlayerTurnState.PlayerTurnBegan -= OnPlayerTurnBegan;
        PlayerTurnState.PlayerTurnEnded -= OnPlayerTurnEnded;
    }

    private void OnPlayerTurnBegan()
    {
        canvasObj.SetActive(true);
        playerTurnTextUI.text = "Player Turn: " + ServiceLocator.GetService<GameMan>().StateTracker.GetState<PlayerTurnState>().PlayerTurnCount;
    }

    private void OnPlayerTurnEnded()
    {
        canvasObj.SetActive(false);
    }
}
