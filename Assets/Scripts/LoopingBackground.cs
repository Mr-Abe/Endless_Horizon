using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform otherBackground; // The other background that this one should follow
    private float spriteWidth;
    private float bufferZone = 1.98f; // Define an appropriate value based on your setup

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteWidth = spriteRenderer.sprite.bounds.size.x * spriteRenderer.transform.localScale.x;
    }

    void Update()
    {
        if (transform.position.x + spriteWidth - bufferZone < cameraTransform.position.x)
        {
            Vector3 newPosition = otherBackground.position;
            newPosition.x += spriteWidth;
            transform.position = newPosition;
        }
    } 
}