using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{
    public float _speed = 10.0f;
    public float _thrust = 45.0f;
    public int _score;
    private bool _isGrounded;
    private Transform _transform;
    private Rigidbody _rb;
    private Animator _animator;
    public bool Rightdirec = true;
    public float gameRestartDelay = 0.5f;

    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _rb = gameObject.GetComponent<Rigidbody>();
        _animator = gameObject.GetComponent<Animator>();
        this._isGrounded = false;
        this._score = 0;
    }

    void Update()
    {
        if(!PauseMenu.isPaused)
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

        if (Physics.gravity.y < 0)
        {
            _thrust *= 1;
        }
        else
        {
            _thrust *= -1;
        }

        // Adjust jump direction based on gravity
        _rb.AddForce(transform.up * _speed * _thrust);
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
        if(collision.gameObject.tag == "Platform")
        {
            this._isGrounded = true;
    		transform.parent = collision.transform;
		}
        if (collision.gameObject.tag == "Spike" || collision.gameObject.tag == "DeathDrop")
        {
            GravityController.resetGravity();
            DelayedRestart();     
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this._isGrounded = false;
        }
        if(collision.gameObject.tag == "Platform"){
    		transform.parent = null;
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

    void DelayedRestart()
    {     
        Destroy(gameObject);                                           
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);  
        //Invoke(nameof(Restart), gameRestartDelay);
    }

}
