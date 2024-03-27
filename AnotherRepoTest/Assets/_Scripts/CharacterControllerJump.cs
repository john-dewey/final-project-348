using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterControllerJump : MonoBehaviour
{
    public CharacterController cc;

    public float gravity = -9.81f;
    public float gravityScale = 1;
    public float jumpHeight = 4;

    float velocity;

    void Update()
    {
        if (cc.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity = Mathf.Sqrt(jumpHeight * -2f * (gravity * gravityScale));
        }

        velocity += gravity * gravityScale * Time.deltaTime;
        MovePlayer();
    }

    void MovePlayer()
    {
        cc.Move(new Vector3(0, velocity, 0) * Time.deltaTime);
    }
}