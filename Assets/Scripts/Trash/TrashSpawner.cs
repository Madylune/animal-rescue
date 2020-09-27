using System.Collections;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trashItems;

    private float minX = -2.5f, maxX = 2.5f;
    private bool isSpawning;
    private enum SpawnState { SPAWNING, WAITING }
    private SpawnState state = SpawnState.SPAWNING;

    private void Start()
    {
        isSpawning = true;
    }

    private void Update()
    {
        if (state == SpawnState.SPAWNING)
        {
            StartCoroutine(SpawnTrash());
        }
    }

    IEnumerator SpawnTrash()
    {
        if (isSpawning)
        {
            state = SpawnState.WAITING;

            int trashIndex = Random.Range(0, 5);
            InstantiateTrash(trashItems[trashIndex]);

            yield return new WaitForSeconds(Random.Range(5, 10));
            state = SpawnState.SPAWNING;
        }
    }

    void InstantiateTrash(GameObject trashItem)
    {

        Vector3 tmp = transform.position;
        Vector2 position = new Vector2(Random.Range(minX, maxX), tmp.y);

        GameObject newTrash = Instantiate(trashItem, position, transform.rotation);

        if (newTrash)
        {
            newTrash.transform.parent = transform;
        }
    }
}
