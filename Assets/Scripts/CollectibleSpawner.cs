using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject[] collectibles; // Array of collectible prefabs
    public Vector2 spawnIntervalRange = new Vector2(1f, 3f);
    public float moveSpeed = 5f;

    private void Start()
    {
        StartSpawning();
    }

    void StartSpawning()
    {
        StartCoroutine(SpawnCollectibles());
    }

    System.Collections.IEnumerator SpawnCollectibles()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnIntervalRange.x, spawnIntervalRange.y));

            int randomCollectibleIndex = Random.Range(0, collectibles.Length);
            GameObject spawnedCollectible = Instantiate(collectibles[randomCollectibleIndex], transform.position, Quaternion.identity);
            spawnedCollectible.AddComponent<CollectibleMovement>().moveSpeed = moveSpeed;
        }
    }
}

public class CollectibleMovement : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}
