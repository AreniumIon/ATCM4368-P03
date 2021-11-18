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
        playerTurnTextUI.text = "Player Turn: " + ServiceLocator.GetService<GameMan>().CardGameSM.GetComponent<PlayerTurnCardGameState>().PlayerTurnCount;
    }

    private void OnPlayerTurnEnded()
    {
        canvasObj.SetActive(false);
    }
}
