using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerTurnUI : MonoBehaviour
{
    [SerializeField] Image tokenCover = null;
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
        Color newColor = tokenCover.color;
        newColor.a = coverAlpha;
        tokenCover.color = newColor;
    }

    private void OnPlayerTurnBegan()
    {
        StartCoroutine(FadeTokenCover(0f));
    }

    private void OnPlayerTurnEnded()
    {
        tokenCover.gameObject.SetActive(true);
        StartCoroutine(FadeTokenCover(coverAlpha));
    }


    private IEnumerator FadeTokenCover(float targetAlpha)
    {
        float startAlpha = tokenCover.color.a;
        float timer = 0;


        Debug.Log("Target: " + targetAlpha);
        Debug.Log("Start: " + startAlpha);

        while (tokenCover.color.a != targetAlpha)
        {
            yield return null;
            timer += Time.deltaTime;

            // Calculate alpha
            float a = Mathf.Lerp(startAlpha, targetAlpha, Mathf.Clamp(timer / fadeTime, 0, 1));

            // Apply alpha
            Color newColor = tokenCover.color;
            newColor.a = a;
            tokenCover.color = newColor;
        }

        // Set object inactive if alpha is 0
        if (targetAlpha == 0)
            tokenCover.gameObject.SetActive(false);
    }
}
