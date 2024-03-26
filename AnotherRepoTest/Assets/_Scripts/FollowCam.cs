using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    // public Camera _cam;

    // void Start(){
    //     _cam = GetComponent<Camera>();
    // }
    void Update()
    {
        if (target)
        {
            float yPos = 0;

            if (target.position.y < 10)
            {
                yPos = 0;
            }
            if (target.position.y > 10)
            {
                yPos = 20;
            }

            Vector3 targetV = target.position;
            Vector3 normalized = new Vector3(targetV.x, yPos, -10);

            transform.position = normalized;
        }
    }
}