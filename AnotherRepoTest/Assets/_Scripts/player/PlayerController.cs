using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 10.0f;
    private bool _isGrounded;
    private Transform _transform;
    private Rigidbody _rb;
    private Animator _animator;
    public bool Rightdirec = true;
    private BoxCollider _boxCollider;

    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _rb = gameObject.GetComponent<Rigidbody>();
        _animator = gameObject.GetComponent<Animator>();
        _boxCollider = gameObject.GetComponent<BoxCollider>(); // Get the BoxCollider component
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
        }
        else if (Input.GetButton("Jump")) // Check if the "top" key is pressed
        {
            Attack(); // Play attack animation
        }

        else
        {
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

        float thrust = 45.0f;

        if (Physics.gravity.y < 0)
        {
            thrust *= 1;
        }
        else
        {
            thrust *= -1;
        }

        // Adjust jump direction based on gravity
        _rb.AddForce(transform.up * _speed * thrust);
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

        if (_isGrounded)
        {
            _animator.Play("walk");
        }

        transform.Translate(translation, 0, 0);

        // Flip the sprite based on direction
        if (horizontalInput > 0)
        {
            rotatePlayer(1);
        }
        else if (horizontalInput < 0)
        {
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
}
