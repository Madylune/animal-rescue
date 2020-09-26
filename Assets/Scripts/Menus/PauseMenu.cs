using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;

    private bool soundOn;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject musicButton;

    private void Start()
    {
        soundOn = AudioListener.volume > 0 ? true : false;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // Freeze time and game
        isPaused = true;
    }

    public void ToggleSound()
    {
        var img = musicButton.GetComponent<Image>();

        var tmp = img.color;

        if (soundOn)
        {
            tmp.a = 0.5f;
            SoundManager.instance.ToggleSound(false);
            soundOn = false;
        }
        else
        {
            tmp.a = 1f;
            SoundManager.instance.ToggleSound(true);
            soundOn = true;
        }

        img.color = tmp;
    }
}
