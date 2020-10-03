using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    [SerializeField]
    private bool isTutorial;

    private bool soundIsPlayed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !soundIsPlayed)
        {
            SoundManager.instance.VictorySound();
            soundIsPlayed = true;

            Invoke("ChangeAfterTime", 3f);
        }
    }

    void ChangeAfterTime()
    {
        if (isTutorial)
        {
            SceneSwitcherManager.instance.LoadMainMenu();
        }
        else
        {
            SceneSwitcherManager.instance.SwitchToNextScene();
        }
    }
}
