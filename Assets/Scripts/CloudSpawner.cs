using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;

    [System.Obsolete]
    void Start() => StartCoroutine(SpawnObstacles());

    [System.Obsolete]
    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, obstacles.Length);
            float minTime = 1f;
            float maxTime = 1.8f;
            float randomTime = Random.Range(minTime, maxTime);
            float randomHeight = Random.Range(3.4f, 4.8f);
            Vector3 spawnPosition = new Vector3(transform.position.x, randomHeight, transform.position.z);
            Instantiate(obstacles[randomIndex], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(randomTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}

