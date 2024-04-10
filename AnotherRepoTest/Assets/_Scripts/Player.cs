using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //These fields will be exposed to Unity so the dev can set the parameters there
    private float speed = 0.05f;
    bool isGrounded;
    private Transform _transformY;
    private Transform _transformX;
    private Vector3 _currentPosY;
    private Vector3 _currentPosX;

    private Rigidbody _rb;

    //public float playerSpeed;  //allows us to be able to change speed in Unity
    //public Vector3 jumpHeight; 
 

    void Start()
    {
        _transformX = gameObject.GetComponent<Transform> ();
        _transformY = gameObject.GetComponent<Transform> ();

        _rb = gameObject.GetComponent<Rigidbody>();

        this.isGrounded = false;

        //_cc = gameObject.GetComponent<CharacterController> ();
        
        _currentPosY = _transformY.position;        
        _currentPosX = _transformX.position;
    }

    void Update()
    {
        //Jump
        if(Input.GetButton("Jump") && isGrounded)
        {
            Jump();
            this.isGrounded = false;
        }

        //Move
        Move(_transformX.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        //is grounded if touching the ground
        if (collision.gameObject.tag == "Ground")
        {
            this.isGrounded = true;
        }
        
    }

        void OnCollisionExit(Collision collision)
    {
        //is not grounded if leaving the ground
        if (collision.gameObject.tag == "Ground")
        {
            this.isGrounded = false;
        }
        
    }

    void Jump()
    {
            float thrust = 400.0f;

            if (Physics.gravity.y < 0)
            {
                thrust *= 1;
            }
            else
            {
                thrust *= -1;
            }
            
            _rb.AddForce(transform.up  * thrust);
        

    }

    void Move(Vector3 x)
    {

        _currentPosX = x;

        float userInputH = Input.GetAxis ("Horizontal");


        if (userInputH < 0)
        {
            _currentPosX -= new Vector3 (speed, 0);
        }
        if (userInputH > 0)
        {
            _currentPosX += new Vector3 (speed, 0);
        }
            
        
        _transformX.position = _currentPosX;


    }
}

