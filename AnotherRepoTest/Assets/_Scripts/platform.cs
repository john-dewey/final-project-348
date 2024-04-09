using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public float moveDistance = 5f;
    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Check if the platform should move to the right or left
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // Move the platform to the right
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // Move the platform to the left
        }

        // Check if the platform has reached its maximum distance to the right
        if (transform.position.x >= startPos.x + moveDistance)
        {
            movingRight = false; // Change direction to left
        }
        // Check if the platform has reached its maximum distance to the left
        else if (transform.position.x <= startPos.x - moveDistance)
        {
            movingRight = true; // Change direction to right
        }
    }
}
