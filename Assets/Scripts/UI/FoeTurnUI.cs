using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoeTurnUI : MonoBehaviour
{
    [SerializeField] GameObject canvasObj;

    private void OnEnable()
    {
        FoeTurnState.FoeTurnBegan += OnFoeTurnBegan;
        FoeTurnState.FoeTurnEnded += OnFoeTurnEnded;
    }

    private void OnDisable()
    {
        FoeTurnState.FoeTurnBegan -= OnFoeTurnBegan;
        FoeTurnState.FoeTurnEnded -= OnFoeTurnEnded;
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
