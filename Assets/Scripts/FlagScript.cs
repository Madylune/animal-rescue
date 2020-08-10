using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("ChangeAfterTime", 2f);
        }
    }

    void ChangeAfterTime()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level02");
    }
}
