using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player
    public float followSpeed = 5f; // Speed at which the camera follows the player
    public Vector3 offset = new Vector3(0, 0, -10); // Keeps the camera slightly behind the player

    private void LateUpdate()
    {
        // Desired position is where the camera wants to be
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, offset.z);
        
        // Lerp smoothly interpolates between the camera's current position and its desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        
        transform.position = smoothedPosition;
    }
}
