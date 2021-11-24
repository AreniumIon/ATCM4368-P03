using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenUI : MonoBehaviour
{
    [SerializeField] GameObject canvasObj = null;

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
        canvasObj.SetActive(false);
    }

    private void OnWinStateBegan()
    {
        canvasObj.SetActive(true);
        AudioHelper.PlayClip2D(Resources.Load<AudioClip>("Audio/Win"), AudioLibrary.AUDIO_VOLUME);
    }

    private void OnWinStateEnded()
    {
        canvasObj.SetActive(false);
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
