using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnUI : MonoBehaviour
{

    [SerializeField] GameObject canvasObj = null;
    [SerializeField] TextMeshProUGUI turnTextUI = null;

    private void OnEnable()
    {
        PlayerTurnState.PlayerTurnBegan += OnPlayerTurnBegan;
    }

    private void OnDisable()
    {
        PlayerTurnState.PlayerTurnBegan -= OnPlayerTurnBegan;
    }

    private void OnPlayerTurnBegan()
    {
        turnTextUI.text = "Turn   " + ServiceLocator.GetService<GameMan>().StateTracker.GetState<PlayerTurnState>().PlayerTurnCount;
        Debug.Log("Player turn: " + ServiceLocator.GetService<GameMan>().StateTracker.GetState<PlayerTurnState>().PlayerTurnCount);
    }
}
