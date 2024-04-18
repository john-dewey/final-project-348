using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelFollow : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    private Animator animator;
    private SpriteRenderer sprite;
    public float offset;
    private bool moveToCenter = false;
    private Vector3 farRightPosition;
    private Vector3 centerPosition;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        farRightPosition = new Vector3(Screen.width, transform.position.y, 0);
        centerPosition = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        targetPosition = new Vector3(farRightPosition.x - 100f, farRightPosition.y + 900f, farRightPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play("follow");
        if (moveToCenter)
        {
            // Move to the center of the screen
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(centerPosition), speed * Time.deltaTime);

            // Check if the angel has reached the center
            if (transform.position == Camera.main.ScreenToWorldPoint(centerPosition))
            {
                moveToCenter = false;
            }
        }
        else
        {
            // Move to the target position
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(targetPosition), speed * Time.deltaTime);
        }
    }

    // Call this method when the player dies
    public void PlayerDied()
    {
        // Move to the center of the screen
        moveToCenter = true;
    }
}

