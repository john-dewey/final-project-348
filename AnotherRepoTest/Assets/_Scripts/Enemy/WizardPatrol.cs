//using System.Collections;
//using UnityEngine;

//public class WizardPatrol : MonoBehaviour
//{

//    public GameObject projectilePrefab; // Reference to the projectile prefab
//    public Transform firePoint; // Point from where the projectile is fired
//    public float fireRate = 1f; // Rate of fire in seconds

//    public float patrolSpeed = 2f;
//    public float retreatSpeed = 3f; // Speed at which the wizard retreats
//    public float patrolRadius = 10f;
//    public float chaseSpeed = 5f;
//    public float attackRange = 5f; // Range at which the wizard starts shooting fireballs
//    public float aggroRadius = 5f;

//    private Transform player;
//    private Vector3 startingPosition;
//    private bool isPatrolling = false;
//    private bool isChasing = false;
//    private bool canAttack = true; // Flag to control the rate of fire

    


//    private Animator anim;

//    void Start()
//    {
//        player = GameObject.FindGameObjectWithTag("Player").transform;
//        startingPosition = transform.position;
//        anim = GetComponent<Animator>(); // Get the Animator component

//        // Start patrolling
//        Patrol();
//    }

    

//    void Update()
//    {
//        if (isPatrolling)
//        {
//            // Check if the player is within aggro radius
//            if (IsPlayerInRange(aggroRadius))
//            {
//                // Stop patrolling and start chasing
//                isPatrolling = false;
//                StopCoroutine(Patroling());
//                ChasePlayer();

//            }
//        }
//        else if (isChasing)
//        {
//            // Check if the player is outside aggro radius
//            if (!IsPlayerInRange(aggroRadius))
//            {
//                // Stop chasing and resume patrolling
//                isChasing = false;
//                StopCoroutine(ContinuousChase());
//                Patrol();
//            }
//        }


//    }
//    void Attack()
//    {
//        // Check if it's time to attack based on fire rate
//        if (canAttack)
//        {
//            anim.SetBool("RangeAttack", true);
//            // Fire the projectile
//            FireProjectile();

//            // Set canAttack to false to prevent firing too frequently
//            stopAttack();
//            // Invoke a method to reset canAttack after the fire rate duration
//            Invoke("ResetCanAttack", fireRate);
//        }
//    }

//    void ResetCanAttack()
//    {
//        canAttack = true;
//    }
//    void stopAttack()
//    {
//        canAttack = false;
//    }
//    void FireProjectile()
//    {
//        // Instantiate the projectile at the fire point position and rotation
//        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

//        // Set the projectile's direction towards the player
//        Vector3 direction = new Vector3(player.position.x - firePoint.position.x, 0, 0).normalized;
//        // Set the projectile's velocity based on the direction and speed
//        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
//        rb.velocity = direction * projectile.GetComponent<Projectile>().speed;
//    }


//    void Patrol()
//    {
//        anim.SetBool("RangeAttack", false);
//        // Start patrolling the player
//        isPatrolling = true;
//        StartCoroutine(Patroling());
//    }

    
//    IEnumerator Patroling()
//    {
//        // Define left and right patrol points
//        Vector3 leftPatrolPoint = startingPosition - transform.right * patrolRadius;
//        Vector3 rightPatrolPoint = startingPosition + transform.right * patrolRadius;

//        while (isPatrolling)
//        {
//            // Move to the left patrol point
//            yield return MoveToPatrolPoint(leftPatrolPoint);

//            // Flip sprite to face left
//            FlipSprite(-1);
//            anim.SetBool("moving", false);
//            // Wait for a random amount of time
//            yield return new WaitForSeconds(Random.Range(3f, 6f));

//            // Move to the right patrol point
//            yield return MoveToPatrolPoint(rightPatrolPoint);

//            // Flip sprite to face right
//            FlipSprite(1);

//            anim.SetBool("moving", false);
//            // Wait for a random amount of time
//            yield return new WaitForSeconds(Random.Range(3f, 6f));
//        }
//    }

//    IEnumerator MoveToPatrolPoint(Vector3 destination)
//    {
//        // Move towards the specified destination
//        while (Vector3.Distance(transform.position, destination) > 0.1f)
//        {
//            Vector3 moveDirection = (destination - transform.position).normalized;
//            transform.position += moveDirection * patrolSpeed * Time.deltaTime;
//            yield return null;
//        }
//    }

//    void ChasePlayer()
//    {
//        // Start chasing the player
//        isChasing = true;
//        StartCoroutine(ContinuousChase());
//    }

//    IEnumerator ContinuousChase()
//    {
//        while (isChasing)
//        {
//            // Calculate direction to the player
//            Vector3 direction = (player.position - transform.position).normalized;

//            // Move back a little if the player is too close
//            if (Vector3.Distance(transform.position, player.position) <= 3f)
//            {
//                transform.position -= direction * chaseSpeed * Time.deltaTime;
//            }
//            else
//            {
//                // Move towards the player only along the x-axis
//                transform.position += direction * chaseSpeed * Time.deltaTime;
//            }

//            // Flip sprite based on movement direction
//            if (direction.x < 0)
//                FlipSprite(1); // Face left
//            else
//                FlipSprite(-1); // Face right

//            // Check if player is within attack range
//            if (IsPlayerInRange(attackRange))
//            {
//                // Call the Attack method
//                Attack();
//            }

//            yield return null;
//        }
//    }



//    void FlipSprite(int direction)
//    {
//        // Multiply the local scale by the direction to flip the sprite
//        Vector3 newScale = transform.localScale;
//        newScale.x = Mathf.Abs(newScale.x) * direction;
//        transform.localScale = newScale;

//        FlipHand(direction);
//    }

//    void FlipHand(int direction)
//    {
//        if (firePoint != null)
//        {
//            // Get the current rotation of the firePoint
//            Vector3 currentRotation = firePoint.localEulerAngles;

//            // Flip the rotation by rotating around the Y-axis
//            currentRotation.y = direction == -1 ? 0f : 180f; // Rotate to face right or left
//            firePoint.localEulerAngles = currentRotation;
//        }
//        else
//        {
//            Debug.LogWarning("Hand reference not set in WizardPatrol!");
//        }
//    }



//    public bool IsPlayerInRange(float radius)
//    {
//        return Vector3.Distance(transform.position, player.position) <= radius;
//    }
//}

