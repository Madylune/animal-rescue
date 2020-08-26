using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject greenStar;

    [SerializeField]
    private GameObject orangeStar;

    [SerializeField]
    private GameObject purpleStar;

    public float spawnTimer = 3f;

    private float currentSpawnTimer;

    private int spawnCount;

    public float minX = -2.5f, maxX = 2.5f;

    private void Update()
    {
        if (GameManager.instance.IsSpawning)
        {
            SpawnStars();
        }
        else
        {
            spawnCount = 4;
            currentSpawnTimer = 0f;
        }
    }

    private void SpawnStars()
    {
        currentSpawnTimer += Time.deltaTime;

        if (currentSpawnTimer >= spawnTimer)
        {
            Vector3 tmp = transform.position;
            tmp.x = Random.Range(minX, maxX);

            GameObject newStar = null;

            spawnCount++;

            if (spawnCount < 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newStar = Instantiate(greenStar, tmp, Quaternion.identity);
                }
            }
            else if (spawnCount == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newStar = Instantiate(orangeStar, tmp, Quaternion.identity);
                }
                else
                {
                    newStar = Instantiate(greenStar, tmp, Quaternion.identity);
                }
            }
            else if (spawnCount == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newStar = Instantiate(purpleStar, tmp, Quaternion.identity);
                }
                else
                {
                    newStar = Instantiate(greenStar, tmp, Quaternion.identity);
                }

                spawnCount = 0;
            }

            if (newStar)
            {
                newStar.transform.parent = transform; // Spawned platforms will be StarsSpawner's children
            }

            currentSpawnTimer = 0f;
        }
    }
}
