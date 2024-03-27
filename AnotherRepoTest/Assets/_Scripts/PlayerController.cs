using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //These fields will be exposed to Unity so the dev can set the parameters there
    private float speed = 0.05f;
    private Transform _transformY;
    private Transform _transformX;
    private Vector3 _currentPosY;
    private Vector3 _currentPosX;

    //public float playerSpeed;  //allows us to be able to change speed in Unity
    public Vector3 jumpHeight; 

    void Update()
    {
        //Move
        Move(_transformX.position, _transformY.position);
    }


    void Move(Vector3 x, Vector3 y)
    {

        _currentPosX = x;
        _currentPosY = y;

        float userInputV = Input.GetAxis ("Vertical");
        float userInputH = Input.GetAxis ("Horizontal");

        if (userInputV < 0) 
            _currentPosY -= new Vector3 (0, speed);     

        if (userInputV > 0)
            _currentPosY += new Vector3 (0, speed);

        if (userInputH < 0)
            _currentPosX -= new Vector3 (speed, 0);

        if (userInputH > 0)
            _currentPosX += new Vector3 (speed, 0);

        _transformY.position = _currentPosY;
        _transformX.position = _currentPosX;
    }


}







    // public float speed = 3.0F;
    // public float rotateSpeed = 3.0F;

    // void Update()
    // {
    //     CharacterController controller = GetComponent<CharacterController>();

    //     Vector3 left = transform.TransformDirection(Vector3.left);
    //     Vector3 right = transform.TransformDirection(Vector3.right);


    //     if (Input.GetButtonDown("Horizontal"))
    //     {

    //     }

    // }






    // if (groundedPlayer && playerVelocity.y < 0)
    //     {
    //         velocity = Mathf.Sqrt(jumpHeight * -2f * (gravity * gravityScale));
    //     }

    //     Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    //     controller.Move(move * Time.deltaTime * playerSpeed);

    //     // if (Input.GetButtonDown("Horizontal") )
    //     // {
    //     //     Vector3 Movement = new Vector3 (Input.GetAxis("Horizontal"), 0, 0);
    
    //     //     controller.transform.position += Movement * playerSpeed * Time.deltaTime;
    //     // }

    //     // Changes the height position of the player..
    //     if (Input.GetButtonDown("Jump") && controller.isGrounded)
    //     {
    //         velocity += Mathf.Sqrt(jumpHeight * 3.0f * gravity);
    //     }

    //     velocity += gravity * Time.deltaTime;
    //     controller.Move(new Vector3(0, velocity, 0) * Time.deltaTime);


