using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public Vector2 spawnIntervalRange = new Vector2(1f, 3f);
    public float groundLevelY = -4.9878f;

    private void Start()
    {
        StartSpawning();
    }

    void StartSpawning()
    {
        StartCoroutine(SpawnObstacles());
    }

    System.Collections.IEnumerator SpawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnIntervalRange.x, spawnIntervalRange.y));

            int randomObstacle = Random.Range(0, obstacles.Length);

            Vector2 spawnPosition = new Vector2(transform.position.x, groundLevelY); 
            Instantiate(obstacles[randomObstacle], spawnPosition, Quaternion.identity);
        }
    }
}
