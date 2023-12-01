using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector2 offset;
    public float max;
    public float min;
    Vector2 position;

    void Update()
    {
        if (target.position.x <= max && target.position.x >= min) position.x = target.position.x + offset.x;
        position.y = target.position.y + offset.y;

        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
