using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 10.0f;
    private bool _isGrounded;
    private Transform _transform;
    private Rigidbody _rb;
    private Animator _animator;
    public bool Rightdirec = true;

    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _rb = gameObject.GetComponent<Rigidbody>();
        _animator = gameObject.GetComponent<Animator>();
        this._isGrounded = false;
    }

    void Update()
    {
        // Jump
        if (Input.GetAxis("Vertical") > 0 && _isGrounded)
        {
            Jump();
            this._isGrounded = false;
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            Move();
            // Change direction based on input
            if (Input.GetAxis("Horizontal") > 0)
            {
                Rightdirec = true;
            }
            else
            {
                Rightdirec = false;
            }
        }
        else if (Input.GetButton("Jump")) // Check if the "top" key is pressed
        {
            Attack(); // Play attack animation
        }

        else
        {
            FlipPlayer();
            Idle();
        }
    }

    void Idle()
    {
        if (_isGrounded)
        {
            _animator.Play("idle");
        }
    }

    void Jump()
    {
        _animator.Play("jump");

        float thrust = 35.0f;

        if (Physics.gravity.y < 0)
        {
            thrust *= 1;
        }
        else
        {
            thrust *= -1;
        }

        // Adjust jump direction based on gravity
        if (Physics.gravity.y < 0)
        {
            _rb.AddForce(transform.up * _speed * thrust);
        }
        else
        {
            _rb.AddForce(transform.up * _speed * -thrust);
        }
    }
    void Attack()
    {
        _animator.Play("attack");
        // Add any attack logic here, such as dealing damage to enemies
    }


    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float translation = horizontalInput * _speed * Time.deltaTime;

        // Adjust movement direction based on gravity
        // Check player's local rotation
        Vector3 localRotation = transform.localRotation.eulerAngles;
        bool isRotated180 = Mathf.Approximately(localRotation.z, 180f);

        // Adjust movement direction based on rotation
        // Adjust movement direction based on rotation
        if (isRotated180)
        {
            horizontalInput *= -1; // Reverse horizontal input if player is rotated 180 degrees on z-axis
            translation = horizontalInput * _speed * Time.deltaTime;
        }


        if (_isGrounded)
        {
            _animator.Play("walk");
        }

        transform.Translate(translation, 0, 0);

        // Flip the sprite based on direction
        if (horizontalInput > 0)
        {
            Rightdirec = true;
            rotatePlayer(1);
        }
        else if (horizontalInput < 0)
        {
            Rightdirec = false;
            rotatePlayer(-1);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && collision.gameObject.tag != "GravityTrigger")
        {
            this._isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this._isGrounded = false;
        }
    }

    void rotatePlayer(int direction)
    {
        // Multiply the local scale by the direction to flip the sprite
        Vector3 newScale = transform.localScale;
        newScale.x = Mathf.Abs(newScale.x) * direction;
        transform.localScale = newScale;
    }

    // Function to flip the player
    void FlipPlayer()
    {
        Vector3 gravityDirection = Physics.gravity.normalized;
        if (gravityDirection.y > 0 && !_isGrounded) // If gravity is pointing upward and player is not grounded
        {
            transform.rotation = Quaternion.Euler(0, 0, 180); // Rotate player 180 degrees around Z-axis (upside down)
        }
        else if (gravityDirection.y < 0 && _isGrounded) // If gravity is pointing downward and player is grounded
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Rotate player back to normal (right side up)
        }
    }

}
