using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGravity : MonoBehaviour
{
    // Reference to the enemy's Rigidbody
    private Rigidbody enemyRigidbody;

    // Constant gravity for the enemy
    public Vector3 enemyGravity = new Vector3(0, -9.8f, 0);

    // Start is called before the first frame update
    void Start()
    {
        // Get the enemy's Rigidbody
        enemyRigidbody = GetComponent<Rigidbody>();

        // Set the constant gravity for the enemy
        enemyRigidbody.useGravity = false; // Disable built-in gravity
    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        // Apply constant gravity to the enemy
        enemyRigidbody.AddForce(enemyGravity, ForceMode.Acceleration);
    }
}