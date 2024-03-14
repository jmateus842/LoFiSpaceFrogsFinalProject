using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public float minTime = 1f;
    public float maxTime = 4f;
    public float maxHeightChange = 0.1f; // Maximum height change

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoRoutine(0));
    }

    // Update is called once per frame
    IEnumerator SpawnCoRoutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        // Calculate the new position with a random height change
        Vector3 spawnPosition = transform.position;
        spawnPosition.y += Random.Range(0, maxHeightChange);

        // Instantiate the platform at the new position
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], spawnPosition, Quaternion.identity);

        // Start the coroutine again with a new random spawn time
        StartCoroutine(SpawnCoRoutine(Random.Range(minTime, maxTime)));
    }
}
