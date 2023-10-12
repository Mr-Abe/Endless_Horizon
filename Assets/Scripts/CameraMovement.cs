using UnityEngine;

public class CameraMoveRight : MonoBehaviour
{
    public float moveSpeed = 5.0f; // The speed at which the camera will move to the right.

    void Update()
    {
        // Move the camera to the right.
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    }
}
