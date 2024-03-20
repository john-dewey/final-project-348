using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //These fields will be exposed to Unity so the dev can set the parameters there
    [SerializeField] private float speed = 1f;
    [SerializeField] private float upY;
    [SerializeField] private float downY;
    [SerializeField] private float leftX;
    [SerializeField] private float rightX;

    private Transform _transformY;
    private Transform _transformX;
    private Vector3 _currentPosY;
    private Vector3 _currentPosX;

    // [Header("Dynamic")]

    // void Awake()
    // {
    //     if (S == null)
    //     {
    //         S = this; // Set the Singleton only if it’s null                  // c
    //     }
    //     else
    //     {
    //         Debug.LogError("Player.Awake() - Attempted to assign second Hero.S!");
    //     }
    // }

    void Start()
    {
        _transformY = gameObject.GetComponent<Transform> ();
        _currentPosY = _transformY.position;        

        _transformX = gameObject.GetComponent<Transform> ();
        _currentPosX = _transformX.position;
    }

    void Update()
    {
        Move(_transformX.position, _transformY.position);
    }


    void Move(Vector3 x, Vector3 y)
    {
        // _currentPosX = _transformX.position;
        // _currentPosY = _transformY.position;

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

        //CheckBoundary ();

        _transformY.position = _currentPosY;
        _transformX.position = _currentPosX;
    }


    // void Start() {…}  // Please delete the unused Start() method
}

