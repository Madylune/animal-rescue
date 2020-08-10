﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScript : MonoBehaviour
{
    [SerializeField]
    private int points;

    [SerializeField]
    private bool isGreen, isOrange, isPurple;

    public float moveSpeed = 3f;

    public float boundY = 6f; // Max y to see the platform

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 tmp = transform.position;
        tmp.y += moveSpeed * Time.deltaTime;
        transform.position = tmp;

        if (tmp.y >= boundY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.LootSound();

            collision.GetComponent<PlayerMovement>().jumpCount += points;
            points = 0;

            Destroy(gameObject);
        }
    }
}
