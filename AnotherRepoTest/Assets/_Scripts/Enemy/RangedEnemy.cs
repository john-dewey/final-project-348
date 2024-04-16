using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider boxCollider; // Changed to BoxCollider for 3D physics

    [Header("Player Tag")]
    [SerializeField] private string playerTag; // New variable to hold the player tag

    private float cooldownTimer = Mathf.Infinity;

    // References
    private Animator anim;
    private EnemyPatrol enemyPatrol;
    private Transform playerTransform;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Get player's transform
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }

        // Attack only when player in sight and within range
        if (playerTransform != null && PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("rangedAttack");
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firepoint.position;
        fireballs[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private bool PlayerInSight()
    {
        if (playerTransform == null)
            return false;

        float distance = Vector3.Distance(transform.position, playerTransform.position);
        return distance <= range;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 center = boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance;
        Vector3 size = new Vector3(boxCollider.bounds.size.x * range * transform.localScale.x, boxCollider.bounds.size.y, 0f);
        Gizmos.DrawWireCube(center, size);
    }
}
