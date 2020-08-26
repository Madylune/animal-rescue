using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float minX = -3.2f, maxX = 3.2f, minY = -5.6f, maxY = 5.6f;

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

        if (tmp.y <= minY || tmp.y >= maxY)
        {
            if (!outOfBounds)
            {
                outOfBounds = true;

                StartCoroutine(Die());
                SoundManager.instance.DeathSound();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "TopSpike")
        {
            StartCoroutine(Die());
            SoundManager.instance.DeathSound();
        }
    }

    private IEnumerator Die()
    {
        GetComponent<PlayerMovement>().TakeDamage();

        yield return new WaitForSeconds(1);
        //transform.position = new Vector2(1000f, 1000f);
        GameManager.instance.RestartGame();
    }
}
