using UnityEngine;
using System.Collections;

public class ColliderResizer : MonoBehaviour
{
    // Original size of the collider
    private Vector3 originalSize;

    // Enlarged size of the collider
    public Vector3 enlargedSize;

    // Reference to the collider component
    private Collider colliderComponent;

    // Delay before returning the collider to its original size
    public float returnDelay = 1f;

    // Flag to track if the collider is currently enlarged
    private bool isEnlarged = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get the collider component attached to the GameObject
        colliderComponent = GetComponent<Collider>();

        // Store the original size of the collider
        originalSize = colliderComponent.bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Enlarge the collider
            ResizeCollider(enlargedSize);
            isEnlarged = true;
        }

        // Check if the space button is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Return the collider to its original size after a delay
            StartCoroutine(ReturnToOriginalSize());
        }
    }

    // Function to resize the collider
    private void ResizeCollider(Vector3 newSize)
    {
        // Disable the collider temporarily to avoid physics glitches
        colliderComponent.enabled = false;

        // Resize the collider
        if (colliderComponent is BoxCollider)
        {
            BoxCollider boxCollider = (BoxCollider)colliderComponent;
            boxCollider.size = newSize;
        }
        else if (colliderComponent is SphereCollider)
        {
            SphereCollider sphereCollider = (SphereCollider)colliderComponent;
            sphereCollider.radius = newSize.x; // Assuming the sphere collider's radius is based on a single float value
        }
  

        // Re-enable the collider
        colliderComponent.enabled = true;
    }

    // Coroutine to return the collider to its original size after a delay
    private IEnumerator ReturnToOriginalSize()
    {
        yield return new WaitForSeconds(returnDelay);

        // Check if the collider is still enlarged (it might have been toggled back already)
        if (isEnlarged)
        {
            ResizeCollider(originalSize);
            isEnlarged = false;
        }
    }
}
