using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalaciteController : MonoBehaviour
{
    private Rigidbody _rb;
    public float deleteObjectDelay = 0.2f;
    public bool breakable = true;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    void DelayedDelete()
    {                                                  
        Invoke(nameof(Delete), deleteObjectDelay);
    }

    void Delete()
    {
        Destroy(gameObject);                      
    }

    void OnCollisionEnter(Collision collision)
    {
        if (breakable && (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("Platform")) )
        {
            DelayedDelete();
        }
    }
}
