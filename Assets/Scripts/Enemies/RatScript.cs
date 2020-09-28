using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatScript : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private float moveSpeed = 3f;
    private float minX = -3.6f;
    private float maxX = 3.6f;

    private enum SpawnState { RUNNING, WAITING }
    private SpawnState state = SpawnState.RUNNING;

    private bool goingToLeft = true;

    private void Update()
    {
        if (state == SpawnState.RUNNING)
        {
            if (goingToLeft)
            {
                RunToLeft();
            }
            else
            {
                RunToRight();
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        state = SpawnState.RUNNING;
    }

    private void RunToLeft()
    {
        Vector2 tmp = transform.position;

        if (tmp.x >= minX)
        {
            tmp.x -= moveSpeed * Time.deltaTime;
        }

        if (tmp.x <= minX)
        {
            goingToLeft = false;
            state = SpawnState.WAITING;
            StartCoroutine(Delay());
            Flip();
        }

        transform.position = tmp;
    }

    private void RunToRight()
    {
        Vector2 tmp = transform.position;

        if (tmp.x <= maxX)
        {
            tmp.x += moveSpeed * Time.deltaTime;
        }

        if (tmp.x >= maxX)
        {
            goingToLeft = true;
            state = SpawnState.WAITING;
            StartCoroutine(Delay());
            Flip();
        }

        transform.position = tmp;
    }

    private void Flip()
    {
        if (spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerMovement>().TakeDamage();
            SoundManager.instance.GameOverSound();
            GameManager.instance.GameOver();
        }
    }
}
