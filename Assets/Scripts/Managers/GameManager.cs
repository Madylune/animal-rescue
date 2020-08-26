using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isSpawning;

    [SerializeField]
    public GameObject gameOverPanel;

    public bool IsSpawning { get => isSpawning; set => isSpawning = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Freeze time and game
    }

    public void RestartGame()
    {
        Invoke("RestartAfterTime", 2f);
    }

    void RestartAfterTime()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
