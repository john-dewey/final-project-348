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

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play("follow");
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        Vector2 target = getY();
       
        transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);

        if (distance > 2)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        }
    }

    private Vector2 getY()
    {
        Vector2 abovePlayer = player.transform.position;

        if(Physics.gravity.y < 0)
        {
            abovePlayer.y = abovePlayer.y + offset;
        }
        else
        {
            abovePlayer.y = abovePlayer.y - offset;
        }
        return abovePlayer;
    }
}
