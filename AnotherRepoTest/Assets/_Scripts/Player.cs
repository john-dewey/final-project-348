using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum eMode { idle, move, attack}

    [Header("Inscribed")]
    public float speed = 5;

    [Header("Dynamic")]
    public int dirHeld = -1; // Direction of the held movement key
    public int              facing = 1;   // Direction Dray is facing 
    public eMode            mode = eMode.idle;

     private Rigidbody2D rigid;
    private Animator        anim;

    private Vector2[] directions = new Vector2[] {
        Vector2.right, Vector2.left};

    private KeyCode[] keys = new KeyCode[] {
      KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow,
      KeyCode.D,          KeyCode.W,       KeyCode.A,         KeyCode.S };    // a


    void Awake(){

        rigid = GetComponent<Rigidbody2D>();
        
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //———————————— Handle Keyboard Input in idle or move Modes ————————————
        if (mode == eMode.idle || mode == eMode.move) {                        // b
            dirHeld = -1;
            for (int i=0; i <keys.Length; i++) {
                if ( Input.GetKey(keys[i]) ) dirHeld = i % 4;                  
            }

            // Choosing the proper movement or idle mode based on dirHeld
            if (dirHeld == -1) {                                               // c
                mode = eMode.idle;
            } else {
                facing = dirHeld; // d
                mode = eMode.move;
            }
        }

        //———————————————————— Act on the current mode ————————————————————
        Vector2 vel = Vector2.zero;
        switch (mode) {                                                        // f
        case eMode.attack: // Show the Attack pose in the correct direction
            anim.Play( "" +facing );
            anim.speed = 0;
            break;

        case eMode.idle:   // Show frame 1 in the correct direction
            anim.Play( "walk_" +facing );
            anim.speed = 0;
            break;

        case eMode.move:   // Play walking animation in the correct direction
            vel = directions[dirHeld];
            anim.Play( "walk_" +facing );
            anim.speed = 1;
            break;
        }

        rigid.velocity = vel * speed;

    }
}
