using System.Collections;
using UnityEngine;

public class FireIncendiary : MonoBehaviour
{
    public GameObject fireEffect; // The fire effect GameObject
    public float interval = 3f; // Time interval between each activation
    private BoxCollider boxCollider; // Reference to the BoxCollider component

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        StartCoroutine(ActivateFire());
    }

    IEnumerator ActivateFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            // Activate the fire effect
            if (fireEffect != null)
            {
                fireEffect.SetActive(true);

                // Activate the BoxCollider trigger during the animation
                boxCollider.isTrigger = true;

                // Deactivate the fire effect after some time
                yield return new WaitForSeconds(3.5f); // Adjust the duration of fire effect
                fireEffect.SetActive(false);

                // Deactivate the BoxCollider trigger after the animation ends
                boxCollider.isTrigger = false;
            }
        }
    }
}
