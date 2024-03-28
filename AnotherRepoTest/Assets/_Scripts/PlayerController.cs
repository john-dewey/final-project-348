using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 10.0f;
    private bool _isGrounded;
    private Transform _transform;
    private Vector3 _currentPosition;
    private Rigidbody _rb;


    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();

        _rb = gameObject.GetComponent<Rigidbody>();

        this._isGrounded = false;

        _currentPosition = _transform.position;
    }

    void Update()
    {
        //Jump
        if (Input.GetButton("Jump") && _isGrounded)
        {
            Jump();
            this._isGrounded = false;
        }

        //Move
        Move();
    }

    void Jump()
    {
        float thrust = 30.0f;

        if (Physics.gravity.y < 0)
        {
            thrust *= 1;
        }
        else
        {
            thrust *= -1;
        }

        _rb.AddForce(transform.up * _speed * thrust);


    }

    void Move()
    {
        // Set the velcoity to move 10 meters per second
        float translation = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        
        //Uodate translation vector
        transform.Translate(translation, 0, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        //is grounded if touching the ground
        if (collision.gameObject.tag == "Ground")
        {
            this._isGrounded = true;
        }

    }

    void OnCollisionExit(Collision collision)
    {
        //is not grounded if leaving the ground
        if (collision.gameObject.tag == "Ground")
        {
            this._isGrounded = false;
        }

    }
}

