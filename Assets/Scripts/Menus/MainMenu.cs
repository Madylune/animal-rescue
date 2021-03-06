﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName;
    public GameObject settingsPanel;

    [SerializeField]
    private GameObject quitButton, tutorialButton;

    private void Start()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            quitButton.SetActive(false);
            tutorialButton.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
