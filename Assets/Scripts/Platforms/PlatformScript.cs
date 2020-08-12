using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float moveSpeed = 2f;

    public float boundY = 6f; // Max y to see the platform

    public bool movingLeft, movingRight, isBreakable, isSpike, isPlatform, isGround, isFalling;

    private Animator anim;

    private Rigidbody2D rb;

    private void Awake()
    {
        if (isBreakable)
        {
            anim = GetComponent<Animator>();
        }
        if (isFalling)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!isGround)
        {
            Vector2 tmp = transform.position;
            tmp.y += moveSpeed * Time.deltaTime;
            transform.position = tmp;

            if (tmp.y >= boundY)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Vector2 tmp = transform.position;
            if (tmp.y < boundY)
            {
                tmp.y += moveSpeed * Time.deltaTime;
                transform.position = tmp;
            }
            else
            {
                BackgroundScroll.instance.isScrolling = false;
            }
        }
    }

    private void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.35f);
    }

    private void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (isSpike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (isBreakable)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }
            if (isPlatform)
            {
                SoundManager.instance.LandSound();
            }
        }

        if (target.gameObject.tag == "Platform" && isFalling)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (movingLeft)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }
            if (movingRight)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
            if (isFalling)
            {
                rb.gravityScale = 1;

                if (transform.position.y <= -6f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
