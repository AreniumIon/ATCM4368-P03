using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenUI : MonoBehaviour
{
    [SerializeField] GameObject canvasObj = null;

    private void OnEnable()
    {
        LoseState.LoseBegan += OnLoseStateBegan;
        LoseState.LoseEnded += OnLoseStateEnded;
    }

    private void OnDisable()
    {
        LoseState.LoseBegan -= OnLoseStateBegan;
        LoseState.LoseEnded -= OnLoseStateEnded;
    }

    private void Start()
    {
        canvasObj.SetActive(false);
    }

    private void OnLoseStateBegan()
    {
        canvasObj.SetActive(true);
        AudioHelper.PlayClip2D(Resources.Load<AudioClip>("Audio/Lose"), AudioLibrary.AUDIO_VOLUME);
    }

    private void OnLoseStateEnded()
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
