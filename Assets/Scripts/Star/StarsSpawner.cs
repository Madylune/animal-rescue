using System.Collections;
using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
    public static StarsSpawner instance;

    public bool isSpawning;
    public enum SpawnState { SPAWNING, WAITING }

    [SerializeField]
    private GameObject[] stars;

    [SerializeField]
    private bool isFalling;

    private float minX = -2.6f, maxX = 2.6f;

    private SpawnState state = SpawnState.SPAWNING;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        isSpawning = true;
    }

    private void Update()
    {
        if (state == SpawnState.SPAWNING)
        {
            StartCoroutine(SpawnStar());
        }
    }

    IEnumerator SpawnStar()
    {
        if (isSpawning)
        {
            state = SpawnState.WAITING;

            int starIndex = Random.Range(0, 2);
            InstantiateStar(stars[starIndex]);

            yield return new WaitForSeconds(Random.Range(7, 10));
            state = SpawnState.SPAWNING;
        }
    }

    void InstantiateStar(GameObject star)
    {
        Vector3 tmp = transform.position;

        Vector2 position = new Vector2(Random.Range(minX, maxX), tmp.y);
        GameObject newStar = Instantiate(star, position, Quaternion.identity);
        if (isFalling)
        {
            newStar.GetComponent<StarScript>().isFalling = true;
        }

        if (newStar)
        {
            newStar.transform.parent = transform; // Spawned platforms will be StarsSpawner's children
        }
    }
}
