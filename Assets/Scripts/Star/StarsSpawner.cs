using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject greenStar;

    [SerializeField]
    private GameObject orangeStar;

    [SerializeField]
    private GameObject purpleStar;

    public float minX = -2.5f, maxX = 2.5f;

    public void SpawnStar()
    {
        Vector3 tmp = transform.position;
        tmp.x = Random.Range(minX, maxX);

        int lot = Random.Range(1, 3);

        GameObject newStar = null;

        if (lot == 1)
        {
            newStar = Instantiate(greenStar, tmp, Quaternion.identity);
        }
        if (lot == 2)
        {
            newStar = Instantiate(orangeStar, tmp, Quaternion.identity);
        }
        if (lot == 3)
        {
            newStar = Instantiate(purpleStar, tmp, Quaternion.identity);
        }

        if (newStar)
        {
            newStar.transform.parent = transform; // Spawned platforms will be StarsSpawner's children
        }
    }
}
