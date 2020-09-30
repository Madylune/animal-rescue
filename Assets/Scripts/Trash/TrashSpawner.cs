using System.Collections;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trashItems;

    [SerializeField]
    private bool isHard, isGround;

    [SerializeField]
    private GameObject flag;

    [SerializeField]
    private GameObject[] spikes;

    [SerializeField]
    private GameObject rat;

    private float minX = -3f, maxX = 3f;
    private bool isSpawning;
    private enum SpawnState { SPAWNING, WAITING }
    private SpawnState state = SpawnState.SPAWNING;

    private int currentLevel;

    float currentTime = 0f;
    float startTime = 0f;
    float endTime = 45f;

    private void Start()
    {
        isSpawning = true;
        currentLevel = LevelManager.instance.currentLevel;

        if (isGround)
        {
            currentTime = startTime;
        }
    }

    private void Update()
    {
        if (isGround)
        {
            currentTime += 1 * Time.deltaTime;

            if (currentTime >= endTime)
            {
                state = SpawnState.WAITING;
                flag.SetActive(true);

                if (StarsSpawner.instance != null)
                {
                    StarsSpawner.instance.isSpawning = false;
                }

                if (spikes != null)
                {
                    foreach (GameObject spike in spikes)
                    {
                        spike.SetActive(false);
                    }
                }

                if (rat != null)
                {
                    rat.SetActive(false);
                }
            }
            else
            {
                if (state == SpawnState.SPAWNING)
                {
                    StartCoroutine(SpawnTrash());
                }
            }
        }
        else
        {
            if (state == SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnTrash());
            }
        }
    }

    IEnumerator SpawnTrash()
    {
        if (isSpawning)
        {
            state = SpawnState.WAITING;

            int trashIndex = Random.Range(0, 5);
            InstantiateTrash(trashItems[trashIndex]);

            if (isGround)
            {
                yield return new WaitForSeconds(Random.Range(1, 2));
            }
            else
            {
                if (isHard)
                {
                    yield return new WaitForSeconds(Random.Range(3, 5));
                }
                else
                {
                    yield return new WaitForSeconds(Random.Range(5, 10));
                }
            }

            state = SpawnState.SPAWNING;
        }
    }

    void InstantiateTrash(GameObject trashItem)
    {

        Vector3 tmp = transform.position;
        Vector2 position = new Vector2(Random.Range(minX, maxX), tmp.y + Random.Range(0, 1));

        GameObject newTrash = Instantiate(trashItem, position, transform.rotation);

        if (newTrash)
        {
            newTrash.transform.parent = transform;
        }
    }
}
