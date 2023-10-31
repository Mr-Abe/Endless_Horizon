using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public float viewZone = 5;
    public float parallaxSpeed;
    private Transform cameraTransform;
    private Transform[] layers;
    private float backgroundSize;
    private int leftIndex;
    private int rightIndex;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;

        Transform referenceLayer = transform.Find("background_1/country-platform-back");
        if (referenceLayer)
        {
            SpriteRenderer spriteRenderer = referenceLayer.GetComponent<SpriteRenderer>();
            if (spriteRenderer)
            {
                backgroundSize = spriteRenderer.sprite.bounds.size.x;
            }
        }
        else
        {
            Debug.LogError("Reference layer not found! Check the naming of your objects.");
        }
    }

    private void Update()
    {
        ScrollRight();
    }

    private void ScrollRight()
    {
        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
        {
            layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);

            // Wrapping indices
            int previousRightIndex = rightIndex;
            rightIndex++;
            leftIndex = previousRightIndex;

            if (rightIndex >= layers.Length)
            {
                rightIndex = 0;
            }
        }
    }
}
