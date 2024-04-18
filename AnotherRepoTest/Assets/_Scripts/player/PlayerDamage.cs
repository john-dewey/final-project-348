using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    
    [SerializeField] public float damage;

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            other.GetComponent<Health>()?.TakeDamage(damage);

    }
}
