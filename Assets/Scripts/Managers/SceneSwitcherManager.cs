using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherManager : MonoBehaviour
{
    public static SceneSwitcherManager instance;

    private int prevScene;
    private int nextScene;
    private int totalScenes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        totalScenes = SceneManager.sceneCountInBuildSettings;
        prevScene = SceneManager.GetActiveScene().buildIndex - 1;
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void SwitchToPrevScene()
    {
        SceneManager.LoadScene(prevScene);
    }

    public void SwitchToNextScene()
    {
        if (nextScene < totalScenes)
        {
            SceneManager.LoadScene(nextScene);

            // Setting Int for Index to unlock next level
            if (nextScene > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextScene);
            }
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

}
