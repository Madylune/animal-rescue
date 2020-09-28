using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    private float minY = 0f;
    private float maxY = 2f;
    private float moveSpeed = 1f;

    private bool isMovingDown = true;


    private void Update()
    {
        if (isMovingDown)
        {
            MoveDown();
        }
        else
        {
            MoveUp();
        }
    }

    private void MoveUp()
    {
        Vector2 tmp = transform.position;

        if (tmp.y <= maxY)
        {
            tmp.y += moveSpeed * Time.deltaTime;
        }

        if (tmp.y >= maxY)
        {
            isMovingDown = true;
        }

        transform.position = tmp;
    }

    private void MoveDown()
    {
        Vector2 tmp = transform.position;

        if (tmp.y >= minY)
        {
            tmp.y -= moveSpeed * Time.deltaTime;
        }

        if (tmp.y <= minY)
        {
            isMovingDown = false;
        }

        transform.position = tmp;
    }
}
