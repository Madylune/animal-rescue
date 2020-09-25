using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    public GameObject gameOverPanel;

    [SerializeField]
    private GameObject actionBar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            actionBar.SetActive(false);
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
