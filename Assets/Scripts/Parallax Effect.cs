using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float parallaxSpeed;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraPosition.x;
        transform.position += Vector3.right * deltaX * parallaxSpeed;
        lastCameraPosition = cameraTransform.position;
    }
}
