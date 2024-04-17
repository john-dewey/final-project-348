using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalaciteController : MonoBehaviour
{
    private Rigidbody _rb;
    public float deleteObjectDelay = 0.2f;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            DelayedDelete();
            Main.HERO_DIED();
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            DelayedDelete();
        }
    }
}
