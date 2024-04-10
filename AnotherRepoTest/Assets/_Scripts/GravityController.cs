using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{

    private Animator _animator;
    static private GravityController _G;
private SpriteRenderer _sprite;

    void Awake()
    {
        _G = this;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            _animator = other.gameObject.GetComponent<Animator>();

            _sprite = other.gameObject.GetComponent<SpriteRenderer>();

            Destroy(gameObject);

            float currentY = Physics.gravity.y;
            float currentZ = Physics.gravity.z;

            if (currentY < 0)
            {

                _sprite.flipY = true;

                _animator.Play("floating");

                GravitateUp();
            }
            
            else
            {
                _sprite.flipY = false;

                _animator.Play("floating");
                
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

        Physics.gravity = new Vector3(0, 9.8f, 0);
    }

    void GravitateDown()
    {    
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }
}
