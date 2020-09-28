using UnityEngine;

public class StarScript : MonoBehaviour
{
    [SerializeField]
    private int points;

    [SerializeField]
    private bool isGreen, isOrange, isPurple;

    public bool isTutorial, isFalling;

    public float moveSpeed = 3f;

    private float maxY = 6f;
    private float minY = -6f;

    private void Update()
    {
        if (!isTutorial)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector2 tmp = transform.position;

        if (isFalling)
        {
            tmp.y -= moveSpeed * Time.deltaTime;
            transform.position = tmp;

            if (tmp.y <= minY)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            tmp.y += moveSpeed * Time.deltaTime;
            transform.position = tmp;

            if (tmp.y >= maxY)
            {
                Destroy(gameObject);
            }
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
