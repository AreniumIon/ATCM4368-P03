using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenUI : MonoBehaviour
{
    [SerializeField] GameObject loseScreenUI = null;

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
        loseScreenUI.SetActive(false);
    }

    private void OnLoseStateBegan()
    {
        loseScreenUI.SetActive(true);
    }

    private void OnLoseStateEnded()
    {
        loseScreenUI.SetActive(false);
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
