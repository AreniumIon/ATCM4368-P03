using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenUI : MonoBehaviour
{
    [SerializeField] GameObject winScreenUI = null;

    private void OnEnable()
    {
        WinState.WinBegan += OnWinStateBegan;
        WinState.WinEnded += OnWinStateEnded;
    }

    private void OnDisable()
    {
        WinState.WinBegan -= OnWinStateBegan;
        WinState.WinEnded -= OnWinStateEnded;
    }

    private void Start()
    {
        winScreenUI.SetActive(false);
    }

    private void OnWinStateBegan()
    {
        winScreenUI.SetActive(true);
    }

    private void OnWinStateEnded()
    {
        winScreenUI.SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }
}
