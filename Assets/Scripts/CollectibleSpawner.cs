using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject[] collectibles; // Array of collectible prefabs
    public int[] collectibleWeights; // Weights for each collectible
    public Vector2 spawnIntervalRange = new Vector2(1f, 3f);
    public float moveSpeed = 5f;

    private void Start()
    {
        // Ensure that the number of weights matches the number of collectibles
        if (collectibles.Length != collectibleWeights.Length)
        {
            Debug.LogError("Mismatch between collectible and weight counts!");
            return;
        }

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

            int totalWeight = 0;
            foreach (int weight in collectibleWeights)
            {
                totalWeight += weight;
            }

            int randomWeightChoice = Random.Range(0, totalWeight);
            int cumulativeWeight = 0;
            int selectedCollectibleIndex = 0;

            for (int i = 0; i < collectibleWeights.Length; i++)
            {
                cumulativeWeight += collectibleWeights[i];
                if (randomWeightChoice < cumulativeWeight)
                {
                    selectedCollectibleIndex = i;
                    break;
                }
            }

            GameObject spawnedCollectible = Instantiate(collectibles[selectedCollectibleIndex], transform.position, Quaternion.identity);
            spawnedCollectible.AddComponent<CollectibleMovement>().moveSpeed = moveSpeed;
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
}
