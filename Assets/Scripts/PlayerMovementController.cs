using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float runSpeed = 0.77f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool isGrounded = false;

    [Header("Ground Detection")]
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GroundCheck();
        MovePlayer();
        Jump();
    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }

    private void MovePlayer()
    {
        // If the "running button" (e.g., left shift) is pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float moveX = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveX * runSpeed, rb.velocity.y);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
        if (isGrounded)
        {
            isJumping = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("Score", ScoreManager.instance.currentScore);

         StartCoroutine(DelayedLoadGameOverScene());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GoldCoin") || other.CompareTag("SilverCoin") || other.CompareTag("BronzeCoin"))
        {
            ScoreManager.instance.CollectCoin(other.tag);
            Destroy(other.gameObject);
        }
    }

    IEnumerator DelayedLoadGameOverScene()
    {
        yield return new WaitForSecondsRealtime(2); // wait for 2 seconds
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
}
