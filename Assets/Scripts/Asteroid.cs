using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;
    public AsteroidData asteroidData; // Reference to the shared AsteroidData Flyweight Requirement

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, asteroidData.speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(asteroidData.explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
