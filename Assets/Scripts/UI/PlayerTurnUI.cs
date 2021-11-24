using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerTurnUI : MonoBehaviour
{
    [SerializeField] Image thoughtBubble = null;
    [SerializeField] Image thoughtBubbleCover = null;
    [SerializeField] float coverAlpha = .5f;
    [SerializeField] float fadeTime = 1f;

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

    private void Start()
    {
        Color newColor = thoughtBubbleCover.color;
        newColor.a = coverAlpha;
        thoughtBubbleCover.color = newColor;
    }

    private void OnPlayerTurnBegan()
    {
        StartCoroutine(MathFunctions.FadeImage(thoughtBubbleCover, coverAlpha, 0f, fadeTime));
    }

    private void OnPlayerTurnEnded()
    {
        StartCoroutine(MathFunctions.FadeImage(thoughtBubbleCover, 0f, coverAlpha, fadeTime));
    }
}
