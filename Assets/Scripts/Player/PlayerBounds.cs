using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float minX = -3.2f, maxX = 3.2f, minY = -5.6f;

    private bool outOfBounds;

    private void Update()
    {
        CheckBounds();
    }

    private void CheckBounds()
    {
        Vector2 tmp = transform.position;

        if (tmp.x > maxX)
        {
            tmp.x = maxX;
        }
        if (tmp.x < minX)
        {
            tmp.x = minX;
        }

        transform.position = tmp;

        if (tmp.y <= minY)
        {
            if (!outOfBounds)
            {
                outOfBounds = true;
                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "TopSpike")
        {
            transform.position = new Vector2(1000f, 1000f);
            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();
        }
    }
}
