using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    // Player speed when moving horizontally.
    [Header("Horizontal Movement")]
    [SerializeField] private float autoRunSpeed = 5f;

    // Components for jumping.
    [Header("Jumping Mechanics")]
    [SerializeField] private float jumpForce = 7f;
    private bool isPlayerJumping = false;
    private Rigidbody2D playerRigidbody;

    // Ground check components.
    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayer; // Assign the layer(s) considered as ground in the Inspector.
    [SerializeField] private Transform groundCheckPoint; // Assign a point slightly below the player to check for ground.
    [SerializeField] private float groundCheckRadius = 0.2f; // Radius for the ground check. Adjust accordingly.

    private void Start()
    {
        // Get the Rigidbody2D component from the player.
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        AutoRun();

        // Check if the player is on the ground.
        bool isPlayerOnGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        if (isPlayerOnGround)
        {
            isPlayerJumping = false; // Reset jumping state if the player is on the ground.
        }

        HandleJumping(isPlayerOnGround);
    }

    /// <summary>
    /// Makes the player character move automatically from left to right.
    /// </summary>
    private void AutoRun()
    {
        transform.Translate(Vector2.right * autoRunSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Handles the player's jumping mechanics.
    /// </summary>
    /// <param name="isPlayerOnGround">Whether the player is currently on the ground.</param>
    private void HandleJumping(bool isPlayerOnGround)
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPlayerJumping && isPlayerOnGround)
        {
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isPlayerJumping = true;
        }
    }
}
