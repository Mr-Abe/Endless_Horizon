using UnityEngine;
 
public class OffscreenDestroyer : MonoBehaviour
{
    private Camera mainCamera;

    public float buffer = 1f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector2 screenPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (screenPosition.x < -buffer || screenPosition.x > 1 + buffer ||
            screenPosition.y < -buffer || screenPosition.y > 1 + buffer)
        {
            Destroy(gameObject);
        }
    }
}