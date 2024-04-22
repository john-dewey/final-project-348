using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float patrolRadius = 10f;
    public float aggroRadius = 5f;

    private Transform player;
    private Vector3 startingPosition;
    private bool isPatrolling = false;
    private bool isChasing = false;

    private Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startingPosition = transform.position;
        anim = GetComponent<Animator>(); // Get the Animator component

        // Start patrolling
        Patrol();
    }

    void Update()
    {
        if (isPatrolling)
        {
            // Check if the player is within aggro radius
            if (IsPlayerInRange(aggroRadius))
            {
                // Stop patrolling and start chasing
                isPatrolling = false;
                StopCoroutine(Patroling());
                ChasePlayer();
                Debug.Log("Chasing Player");
            }
        }
        else if (isChasing)
        {
            // Check if the player is outside aggro radius
            if (!IsPlayerInRange(aggroRadius))
            {
                // Stop chasing and resume patrolling
                isChasing = false;
                StopCoroutine(ContinuousChase());
                Patrol();
                Debug.Log("Going back to patrol Player");
            }
        }

      
    }

    void Patrol()
    {
        // Start patrolling the player
        isPatrolling = true;
        StartCoroutine(Patroling());
    }

    IEnumerator Patroling()
    {
        // Define left and right patrol points
        Vector3 leftPatrolPoint = startingPosition - transform.right * patrolRadius;
        Vector3 rightPatrolPoint = startingPosition + transform.right * patrolRadius;

        while (isPatrolling)
        {
            // Move to the left patrol point
            yield return MoveToPatrolPoint(leftPatrolPoint);

            // Flip sprite to face left
            FlipSprite(-1);
            anim.SetBool("moving", false);
            // Wait for a random amount of time
            yield return new WaitForSeconds(Random.Range(3f, 6f));

            // Move to the right patrol point
            yield return MoveToPatrolPoint(rightPatrolPoint);

            // Flip sprite to face right
            FlipSprite(1);

            anim.SetBool("moving", false);
            // Wait for a random amount of time
            yield return new WaitForSeconds(Random.Range(3f, 6f));
        }
    }

    IEnumerator MoveToPatrolPoint(Vector3 destination)
    {
        // Move towards the specified destination
        while (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            anim.SetBool("moving", true);
            Vector3 moveDirection = (destination - transform.position).normalized;
            transform.position += moveDirection * patrolSpeed * Time.deltaTime;
            yield return null;
        }
    }

    void ChasePlayer()
    {
        // Start chasing the player
        isChasing = true;
        StartCoroutine(ContinuousChase());
    }

    IEnumerator ContinuousChase()
    {
        while (isChasing)
        {
            // Calculate direction to the player only along the x-axis
            Vector3 direction = new Vector3(player.position.x - transform.position.x, 0, 0).normalized;
            anim.SetBool("moving", true);
            // Move towards the player only along the x-axis
            transform.position += direction * chaseSpeed * Time.deltaTime;

            // Flip sprite based on movement direction
            if (direction.x < 0)
                FlipSprite(1); // Face left
            else
                FlipSprite(-1); // Face right

            // Check if player is within attack range
            if (Vector3.Distance(transform.position, player.position) <= 1.5f)
            {
                // You can add code here for attacking the player
                Debug.Log("Attacking Player");
            }

            yield return null;
        }
    }

    void FlipSprite(int direction)
    {
        // Multiply the local scale by the direction to flip the sprite
        Vector3 newScale = transform.localScale;
        newScale.x = Mathf.Abs(newScale.x) * direction;
        transform.localScale = newScale;
    }

    public bool IsPlayerInRange(float radius)
    {
        if (player == null) return false;
        return Vector3.Distance(transform.position, player.position) <= radius;
    }
}
