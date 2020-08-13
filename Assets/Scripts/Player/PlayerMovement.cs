using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public Animator anim;

    public SpriteRenderer spriteRenderer;

    public float moveSpeed = 2f;

    public float jumpVelocity = 7f;

    public int jumpCount = 0;

    public Text starCountText;

    private bool isDying;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        starCountText.text = jumpCount.ToString();
    }

    private void FixedUpdate()
    {
        Move();
        Flip(rb.velocity.x);
    }

    private void Move()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    private void Flip(float velocity)
    {
        if (velocity > 0.1f)
        {
            spriteRenderer.flipX = false; 
        }
        else if (velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void PlatformMove(float x)
    {
        rb.velocity = new Vector2(x, rb.velocity.y);
    }

    private void Jump()
    {
        if (jumpCount > 0 && !isDying)
        {
            jumpCount--;

            rb.velocity = Vector2.up * jumpVelocity;
            SoundManager.instance.FlapSound();
        }
    }

    public void TakeDamage()
    {
        isDying = true;
        anim.SetTrigger("Damage");
    }
}
