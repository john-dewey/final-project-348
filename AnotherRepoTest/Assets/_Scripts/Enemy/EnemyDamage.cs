using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] public float damage;

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<Health>()?.TakeDamage(damage);

    }
}
