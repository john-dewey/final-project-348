using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //These fields will be exposed to Unity so the dev can set the parameters there
    private float speed = 0.05f;
    private Transform _transformY;
    private Transform _transformX;
    private Vector3 _currentPosY;
    private Vector3 _currentPosX;

    //public float playerSpeed;  //allows us to be able to change speed in Unity
    public Vector3 jumpHeight; 
 

    void Start()
    {
        _transformX = gameObject.GetComponent<Transform> ();
        _transformY = gameObject.GetComponent<Transform> ();
        
        _currentPosY = _transformY.position;        
        _currentPosX = _transformX.position;
    }

    void Update()
    {
        //Move
        Move(_transformX.position, _transformY.position);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))  //makes player jump
        {
            if (Physics.gravity.y < 0)
            {
                jumpHeight = new Vector3(0,6,0);
            }
            else
            {
                jumpHeight = new Vector3(0,-6,0);
            }

            GetComponent<Rigidbody>().AddForce(jumpHeight, ForceMode.Impulse);
        }
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

