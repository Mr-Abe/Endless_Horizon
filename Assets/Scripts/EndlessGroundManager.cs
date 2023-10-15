using System.Collections.Generic;
using UnityEngine;

public class EndlessGroundManager : MonoBehaviour
{
    [Header("Settings")]
    public GameObject groundPrefab;
    public int numberOfTiles = 3; // Number of ground tiles in the pool
    public float tileWidth = 10f; // Width of your tile, this needs to be set accurately
    public float speed = 5f; // The speed at which the ground moves

    // List to manage the ground tiles
    private List<GameObject> groundTiles = new List<GameObject>();

    private void Start()
    {
        // Instantiate and setup the initial tiles
        InitializeTiles();
    }

    private void Update()
    {
        MoveAndRecycleTiles();
    }

    // Instantiate the initial set of ground tiles
    private void InitializeTiles()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            GameObject tile = Instantiate(groundPrefab, transform);
            tile.transform.position = new Vector2(i * tileWidth, -4.9878f); 
            groundTiles.Add(tile);
        }
    }

    // Move the ground tiles to the left
    private void MoveAndRecycleTiles()
    {
        foreach (GameObject tile in groundTiles)
        {
            // Move the tile to the left based on the speed
            tile.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

            // If the tile is out of view, recycle it
            if (tile.transform.position.x + tileWidth < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect)
            {
                // Move the tile to the rightmost position of the last tile in the list
                tile.transform.position = new Vector2(groundTiles[groundTiles.Count - 1].transform.position.x + tileWidth, tile.transform.position.y);

                // Reorder the list: Remove the tile from the start and add it to the end
                groundTiles.RemoveAt(0);
                groundTiles.Add(tile);
            }
        }
    }
}
