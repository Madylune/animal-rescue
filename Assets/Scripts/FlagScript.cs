using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.VictorySound();
            Invoke("ChangeAfterTime", 3f);
        }
    }

    void ChangeAfterTime()
    {
        SceneSwitcherManager.instance.SwitchToNextScene();
    }
}
