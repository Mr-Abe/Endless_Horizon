using UnityEngine;

[CreateAssetMenu(fileName = "AsteroidData", menuName = "Flyweight/AsteroidData")]
public class AsteroidData : ScriptableObject
{
    public GameObject explosionPrefab;
    public float speed = -5f;
}
