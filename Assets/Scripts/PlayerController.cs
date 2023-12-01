using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 1.7f;
    bool isWalking;
    bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject scoreText;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource coinSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isWalking = false;
    }

    void FixedUpdate()
    {
        Movement();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Update()
{
    if (Time.timeScale == 0) return;

    HandleAnimations();
    HandleDirection();

    bool jumpPressed = Input.GetButtonDown("Jump");
    if (jumpPressed && isGrounded)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    
    // Debug output to check the conditions
    Debug.Log("Jump Pressed: " + jumpPressed);
    Debug.Log("Is Grounded: " + isGrounded);
}


    void Movement()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
    }

    void HandleAnimations()
    {
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isGrounded", isGrounded);
    }

    void HandleDirection()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && rb.velocity.sqrMagnitude > 0.01f)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                spriteRenderer.flipX = true;
            }

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                spriteRenderer.flipX = false;
            }

            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            backgroundMusic.Stop();
            scoreText.SetActive(false);
            gameoverPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coinSound.Play();
            Score.score++;
        }
    }
}
