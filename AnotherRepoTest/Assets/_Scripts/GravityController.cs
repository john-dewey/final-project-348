using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{

    private Animator _animator;
    static private GravityController _G;

    void Awake()
    {
        _G = this;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            _animator = other.gameObject.GetComponent<Animator>();

            Destroy(gameObject);

            float currentY = Physics.gravity.y;
            float currentZ = Physics.gravity.z;

            if (currentY < 0)
            {
                GravitateUp();
            }
            
            else
            {
                GravitateDown();
            }
        }
    }

    public static void resetGravity()
    {
        _G.GravitateDown();
    }

    void GravitateUp()
    {
        _animator.Play("floating");

        Physics.gravity = new Vector3(0, 9.8f, 0);
    }

    void GravitateDown()
    {
         _animator.Play("floating");
         
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }
}
