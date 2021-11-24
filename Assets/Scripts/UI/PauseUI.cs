using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject canvasObj = null;

    bool isPaused = false;

    private void Start()
    {
        Unpause();
        ServiceLocator.GetService<GameMan>().InputController.PressedCancel += TogglePause;
    }

    public void TogglePause()
    {
        Debug.Log("toggle");
        if (isPaused)
            Unpause();
        else
            Pause();
    }

    public void Pause()
    {
        isPaused = true;
        canvasObj.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        isPaused = false;
        canvasObj.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
}
