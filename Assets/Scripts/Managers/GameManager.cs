using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    public GameObject gameOverPanel;

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
