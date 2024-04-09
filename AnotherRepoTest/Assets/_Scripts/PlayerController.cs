using UnityEngine;
using System.Collections;

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
        _transform = transform;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _isGrounded = false;
    }

    void Update()
    {
        HandleJump();
        HandleMovement();
        HandleAttack();
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jump();
            _isGrounded = false;
        }
    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            Move(horizontalInput);
        }
        else
        {
            Idle();
        }
    }

    void HandleAttack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(AttackCoroutine());
            }
        }

    IEnumerator AttackCoroutine()
    {
        _animator.SetBool("Fire", true);

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

        float thrust = 40.0f * (Physics.gravity.y < 0 ? 1 : -1);
        _rb.AddForce(transform.up * _speed * thrust);
    }

    void Move(float direction)
    {
        _sprite.flipX = direction < 0;

        if(_isGrounded){
            
            _animator.Play("walk");

        }

        else{

            _animator.Play("jump");
        }

        float translation = direction * _speed * Time.deltaTime;
        transform.Translate(translation, 0, 0);
    }

    void Attack()
    {
        _animator.Play("attack");
        // Implement attack logic here
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && collision.gameObject.tag != "GravityTrigger")
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            _isGrounded = false;
    		transform.parent = null;
        }

        
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _isGrounded = true;
    		transform.parent = collision.gameObject.transform;
        }
    }
}
