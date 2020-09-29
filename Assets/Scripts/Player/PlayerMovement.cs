using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public bool isSpawning;

    private Rigidbody2D rb;

    public Animator anim;

    public SpriteRenderer spriteRenderer;

    public float moveSpeed = 2f;

    public float jumpVelocity = 7f;

    public int jumpCount = 0;

    public Text starCountText;

    private bool isDying;

    public Rigidbody2D MyRb { get => rb; set => rb = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        MyRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") || CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Jump();
        }

        starCountText.text = jumpCount.ToString();
    }

    private void FixedUpdate()
    {
        Move();
        Flip(MyRb.velocity.x);
    }

    private void Move()
    {
        anim.SetFloat("Speed", Mathf.Abs(MyRb.velocity.x));

        if (Input.GetAxisRaw("Horizontal") > 0f || CrossPlatformInputManager.GetAxis("Horizontal") > 0f)
        {
            MyRb.velocity = new Vector2(moveSpeed, MyRb.velocity.y);
        }
        if (Input.GetAxisRaw("Horizontal") < 0f || CrossPlatformInputManager.GetAxis("Horizontal") < 0f)
        {
            MyRb.velocity = new Vector2(-moveSpeed, MyRb.velocity.y);
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

    public void PlatformMove(float x) //Move player on moving platforms
    {
        MyRb.velocity = new Vector2(x, MyRb.velocity.y);
    }

    public void Jump()
    {
        if (jumpCount > 0 && !isDying && Time.timeScale > 0f)
        {
            jumpCount--;

            MyRb.velocity = Vector2.up * jumpVelocity;
            SoundManager.instance.FlapSound();
            anim.SetBool("IsJumping", true);
        }
    }

    public void onLanding()
    {
        anim.SetBool("IsJumping", false);
    }

    public void TakeDamage()
    {
        isDying = true;
        anim.SetTrigger("Damage");
    }
}
