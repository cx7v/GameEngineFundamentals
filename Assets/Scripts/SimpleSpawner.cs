using System.Collections;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject prefabToSpawn;
    public float spawnDelay = 2f;

    [Tooltip("How many objects to spawn at once each interval")]
    public int spawnAmount = 1;

    [Header("Limit Settings")]
    [Tooltip("The total maximum number of zombies allowed to spawn")]
    public int maxSpawnLimit = 20;

    // Keeps track of how many zombies have been created total
    private int totalSpawnedCount = 0;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            if (prefabToSpawn != null)
            {
                for (int i = 0; i < spawnAmount; i++)
                {
                    // Check if we have reached or exceeded our total limit
                    if (totalSpawnedCount >= maxSpawnLimit)
                    {
                        Debug.Log("Spawn limit reached! Ceasing all spawning operations.");
                        yield break; // Instantly kills and exits the Coroutine forever
                    }

                    // Add a tiny random offset so they don't stack perfectly on top of each other
                    Vector3 randomOffset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

                    Instantiate(prefabToSpawn, transform.position + randomOffset, transform.rotation);

                    // Increment the counter by 1 for every single zombie born
                    totalSpawnedCount++;
                }
            }
            else
            {
                Debug.LogError("Please assign an object to 'Prefab To Spawn' in the Inspector!");
                yield break; // Stop the script if nothing is assigned
            }
        }
    }
}
