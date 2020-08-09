using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject regularPlatform;
    public GameObject spikePlatform;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;
    public GameObject groundPlatform;

    public float spawnTimer = 1.8f;

    private float currentSpawnTimer;

    private int spawnCount;

    public float minX = -2f, maxX = 2f;

    private void Start()
    {
        currentSpawnTimer = spawnTimer;
    }

    private void Update()
    {
        SpawnPlatforms();
    }

    private void SpawnPlatforms()
    {
        currentSpawnTimer += Time.deltaTime;

        if (currentSpawnTimer >= spawnTimer) //Spawn platform
        {
            BackgroundScroll.instance.isScrolling = true;

            spawnCount++;

            Vector3 tmp = transform.position;
            tmp.x = Random.Range(minX, maxX);

            GameObject newPlatform = null;

            if (spawnCount < 2)
            {
                newPlatform = Instantiate(regularPlatform, tmp, Quaternion.identity);
            }
            else if (spawnCount == 2)
            {
                if (Random.Range(0,2) > 0)
                {
                    newPlatform = Instantiate(regularPlatform, tmp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(movingPlatforms[Random.Range(0,movingPlatforms.Length)], tmp, Quaternion.identity);
                }
            }
            else if (spawnCount == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(regularPlatform, tmp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatform, tmp, Quaternion.identity);
                }
            }
            else if (spawnCount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(regularPlatform, tmp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatform, tmp, Quaternion.identity);
                }

                spawnCount = Random.Range(0, 5);
            }
            else if (spawnCount == 5)
            {
                tmp.x = 0;

                newPlatform = Instantiate(groundPlatform, tmp, Quaternion.identity);
            }

            if (newPlatform)
            {
                newPlatform.transform.parent = transform; // Spawned platforms will be PlatformSpawner's children
            }

            currentSpawnTimer = 0f;
        }
    }
}
