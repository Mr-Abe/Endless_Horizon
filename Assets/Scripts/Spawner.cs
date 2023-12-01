using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    [SerializeField] float spawnRate = 3f;
    float spawnTimer;
    [SerializeField] Transform target;
    [SerializeField] float minPosition = -15f;
    [SerializeField] float maxPosition = -40f;

    void Start()
    {
        spawnTimer = 0f;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(target.position.x - 10f, target.position.x + 10f), 6.5f);

            Instantiate(spawnObject, spawnPosition, spawnObject.transform.rotation);

            spawnTimer = 0f;
        }
    }
}
