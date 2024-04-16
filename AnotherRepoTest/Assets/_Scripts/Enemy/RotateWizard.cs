using UnityEngine;

public class RotateWizard : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate direction vector from the enemy to the player
            Vector2 direction = playerTransform.position - transform.position;

            // Check the direction of the player relative to the enemy
            float yRotation = (direction.x > 0) ? 0f : 180f;

            // Create a Quaternion representing the desired rotation
            Quaternion targetRotation = Quaternion.Euler(0f, yRotation, 0f);

            // Set the rotation instantly
            transform.rotation = targetRotation;
        }
    }
}
