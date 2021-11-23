using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerTurnUI : MonoBehaviour
{
    [SerializeField] Image darkenImage = null; 

    public Transform tokenParent;

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
        darkenImage.gameObject.SetActive(false);
    }

    private void OnPlayerTurnEnded()
    {
        darkenImage.gameObject.SetActive(true);
    }

    // TODO: Coroutine at start and end of player turn to fade image alpha value in/out
}
