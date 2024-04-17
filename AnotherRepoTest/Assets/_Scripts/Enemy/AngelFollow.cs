using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelFollow : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            abovePlayer.y = abovePlayer.y + 10;
        }
        else
        {
            abovePlayer.y = abovePlayer.y - 10;
        }
        return abovePlayer;
    }
}