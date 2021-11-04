using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardGameUIController : MonoBehaviour
{
    [SerializeField] GameObject playerTurnUI = null;
    [SerializeField] TextMeshProUGUI playerTurnTextUI = null;
    [SerializeField] GameObject enemyTurnUI = null;
    [SerializeField] TextMeshProUGUI enemyThinkingTextUI = null;

    [SerializeField] PlayerTurnCardGameState playerTurnState;

    private void OnEnable()
    {
        PlayerTurnCardGameState.PlayerTurnBegan += OnPlayerTurnBegan;
        PlayerTurnCardGameState.PlayerTurnEnded += OnPlayerTurnEnded;
        EnemyTurnCardGameState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded += OnEnemyTurnEnded;
    }

    private void OnDisable()
    {
        PlayerTurnCardGameState.PlayerTurnBegan -= OnPlayerTurnBegan;
        PlayerTurnCardGameState.PlayerTurnEnded -= OnPlayerTurnEnded;
        EnemyTurnCardGameState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded -= OnEnemyTurnEnded;
    }

    private void Start()
    {
        // make sure text is disabled on start
        enemyTurnUI.SetActive(false);
    }

    private void OnPlayerTurnBegan()
    {
        playerTurnUI.SetActive(true);
        playerTurnTextUI.text = "Player Turn: " + playerTurnState.PlayerTurnCount;
    }

    private void OnPlayerTurnEnded()
    {
        playerTurnUI.SetActive(false);
    }

    private void OnEnemyTurnBegan()
    {
        enemyTurnUI.SetActive(true);
    }

    private void OnEnemyTurnEnded()
    {
        enemyTurnUI.SetActive(false);
    }

}
