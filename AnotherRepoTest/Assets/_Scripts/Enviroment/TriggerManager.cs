using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public GameObject[] _objects;
    private SpriteRenderer _renderer;
    private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        _renderer = other.gameObject.GetComponent<SpriteRenderer>();
        _animator = other.gameObject.GetComponent<Animator>();

        if (other.CompareTag("Player") && this.tag == "GravityTrigger")
        {
            Destroy(gameObject);

            if (Physics.gravity.y < 0)
            {

                GravityController.GravitateUp(_renderer, _animator);
            }
            else
            {
                GravityController.GravitateDown(_renderer, _animator);
            }
        }

        if (other.CompareTag("Player") && this.tag == "StalaciteTrigger")
        {
            foreach (GameObject currentObject in _objects)
            {
                Rigidbody rb = currentObject.GetComponent<Rigidbody>();
                rb.isKinematic = false;
            }
        }

        if (other.CompareTag("Player") && this.tag == "JumpBoost")
        {
            Destroy(gameObject);

            PlayerController PC = other.GetComponent<PlayerController>();
            PC._thrust += 15;
        }

        if (other.CompareTag("Player") && this.tag == "Coin")
        {
            Destroy(gameObject);

            PlayerController PC = other.GetComponent<PlayerController>();
            PC._score += 1;
        }

        if (other.CompareTag("Player") && this.tag == "SpeedBoost")
        {
            Destroy(gameObject);

            PlayerController PC = other.GetComponent<PlayerController>();
            PC._speed += 5;
        }

        if (other.CompareTag("Player") && this.tag == "Health")
        {
            Destroy(gameObject);

            PlayerController PC = other.GetComponent<PlayerController>();
        }
    }
}
