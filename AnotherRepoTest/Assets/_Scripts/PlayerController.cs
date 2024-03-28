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
        if (Input.GetButton("Jump") && _isGrounded)
        {
            Jump();
            this._isGrounded = false;
        }

        else if(Input.GetAxis("Horizontal") != 0){

            Move();
        }
        else{
            
            Idle();
        }
        
    }

    void Idle(){

        _animator.Play("idle");
    }
    void Jump()
    {
        float thrust = 30.0f;

        if (Physics.gravity.y < 0)
        {
            _animator.Play("jump");
            thrust *= 1;
        }
        else
        {

            _animator.Play("jump");
            thrust *= -1;
        }

        _rb.AddForce(transform.up * _speed * thrust);
    }

    void Move()
    {
        float translation = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        _animator.Play("walk");
        transform.Translate(translation, 0, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
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
}
