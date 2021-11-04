using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardGameUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemyThinkingTextUI = null;

    private void OnEnable()
    {
        EnemyTurnCardGameState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded += OnEnemyTurnEnded;
    }

    private void OnDisable()
    {
        EnemyTurnCardGameState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded -= OnEnemyTurnEnded;
    }

    private void Start()
    {
        // make sure text is disabled on start
        enemyThinkingTextUI.gameObject.SetActive(false);
    }

    private void OnEnemyTurnBegan()
    {
        enemyThinkingTextUI.gameObject.SetActive(true);
    }

    private void OnEnemyTurnEnded()
    {
        enemyThinkingTextUI.gameObject.SetActive(false);
    }
}
