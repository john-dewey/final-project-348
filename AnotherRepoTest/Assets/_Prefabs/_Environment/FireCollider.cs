using UnityEngine;

public class FireCollider : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float damageInterval = 1f; // Time interval between each damage dealt
    private float damageTimer = 0f; // Timer for damage interval
    private bool isDamaging = false; // Flag to track if player is currently taking damage

    protected void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isDamaging)
            {
                // Start damaging the player
                isDamaging = true;
                InvokeRepeating("DealDamage", 0f, damageInterval); // Start dealing damage at intervals
            }
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop damaging the player when they leave the trigger zone
            isDamaging = false;
            CancelInvoke("DealDamage"); // Stop dealing damage
        }
    }

    private void DealDamage()
    {
        // Deal damage to the player
        var playerHealth = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Health>();
        playerHealth?.TakeDamage(damage);
    }
}
