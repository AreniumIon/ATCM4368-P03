using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoeTurnUI : MonoBehaviour
{
    [SerializeField] GameObject canvasObj;

    [SerializeField] TextMeshProUGUI foeThinkingText = null;

    private void OnEnable()
    {
        EnemyTurnCardGameState.EnemyTurnBegan += OnFoeTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded += OnFoeTurnEnded;
    }

    private void OnDisable()
    {
        EnemyTurnCardGameState.EnemyTurnBegan -= OnFoeTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded -= OnFoeTurnEnded;
    }

    private void Start()
    {
        // make sure text is disabled on start
        canvasObj.SetActive(false);
    }

    private void OnFoeTurnBegan()
    {
        canvasObj.SetActive(true);
    }

    private void OnFoeTurnEnded()
    {
        canvasObj.SetActive(false);
    }
}
