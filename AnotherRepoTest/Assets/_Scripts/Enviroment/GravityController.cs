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

    // private void OnTriggerEnter(Collider other)
    // {

    //     if (other.CompareTag("Player"))
    //     {
    //         _animator = other.gameObject.GetComponent<Animator>();

    //         _sprite = other.gameObject.GetComponent<SpriteRenderer>();

    //         Destroy(gameObject);

    //         float currentY = Physics.gravity.y;
    //         float currentZ = Physics.gravity.z;

    //         if (currentY < 0)
    //         {

    //             _sprite.flipY = true;

    //             _animator.Play("floating");

    //             GravitateUp();
    //         }
            
    //         else
    //         {
    //             _sprite.flipY = false;

    //             _animator.Play("floating");
                
    //             GravitateDown();
    //         }
    //     }
    // }

    public static void resetGravity()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }

    public static void GravitateUp(SpriteRenderer renderer, Animator animator)
    {
        renderer.flipY = true;

        animator.Play("floating");

        Physics.gravity = new Vector3(0, 9.8f, 0);
    }

    public static void GravitateDown(SpriteRenderer renderer, Animator animator)
    {    
        renderer.flipY = false;

        animator.Play("floating");

        Physics.gravity = new Vector3(0, -9.8f, 0);
    }
}
