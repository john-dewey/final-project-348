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
    private SpriteRenderer _sprite;


    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _rb = gameObject.GetComponent<Rigidbody>();
        _animator = gameObject.GetComponent<Animator>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();

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

        else if(Input.GetKeyDown(KeyCode.Z) && _isGrounded){

            attack();

        }
        // move

        else if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0){

            Move();
        }
        else{
            Idle();
        }
        
    }

    void Idle(){
        if(_isGrounded){
            _animator.Play("idle");
        }
    }
    void Jump()
    {

        float direction = Input.GetAxis("Horizontal");
        
        if(direction > 0){
        
            _animator.Play("jump");

        }
        
        else if(direction < 0){

            _sprite.flipX = true;

            _animator.Play("jump");
        }

        else{

            _animator.Play("jump");
        }

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
        _sprite.flipX = false;

        float direction = Input.GetAxis("Horizontal");

        float translation = direction * _speed * Time.deltaTime;

        if(_isGrounded){

            if(direction > 0){

                _animator.Play("walk");

            }

            else if(direction < 0){

                _sprite.flipX = true;
                
                _animator.Play("walk");
            }

            
        }
        transform.Translate(translation, 0, 0);
    }

    void attack(){

            _animator.Play("jump");

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
}
