using UnityEngine;

public class Coin : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = -5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Collider2D coinCollider = GetComponent<Collider2D>();
        if (coinCollider == null) return;

        IgnoreCollisionsWithTag(coinCollider, "Asteroid");
        IgnoreCollisionsWithTag(coinCollider, "Coin");
    }

    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private void IgnoreCollisionsWithTag(Collider2D collider, string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objects)
        {
            Collider2D otherCollider = obj.GetComponent<Collider2D>();
            if (otherCollider != null && otherCollider != collider)
            {
                Physics2D.IgnoreCollision(collider, otherCollider);
            }
        }
    }
}
