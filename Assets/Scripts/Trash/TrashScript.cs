using UnityEngine;

public class TrashScript : MonoBehaviour
{
    [SerializeField]
    private float boundY = -13f;

    private void Update()
    {
        Fall();
    }

    private void Fall()
    {
        Vector2 tmp = transform.position;
        if (tmp.y <= boundY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().TakeDamage();
            SoundManager.instance.GameOverSound();
            GameManager.instance.GameOver();
        }
    }
}
