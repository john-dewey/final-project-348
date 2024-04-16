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

        if (other.CompareTag("Player") && this.gameObject.name == "StalaciteTrigger")
        {
            foreach (GameObject currentObject in _objects)
            {
                Rigidbody rb = currentObject.GetComponent<Rigidbody>();
                rb.isKinematic = false;
            }
        }
    }
}
