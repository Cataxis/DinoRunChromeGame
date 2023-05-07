using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 1.8f;

    private float currentSpawnTime;

    private void Start()
    {
        currentSpawnTime = GetRandomSpawnTime();
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentSpawnTime);

            int randomIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity);

            currentSpawnTime = GetRandomSpawnTime();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    private float GetRandomSpawnTime()
    {
        return Random.Range(minSpawnTime, maxSpawnTime);
    }
}

