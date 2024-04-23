using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryTrigger : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Animator _animator;

    public GameObject DialougeBox;

    public LevelLoader levelLoader;

    public MemoryPiece memoryPieceScript;
    private void OnTriggerEnter(Collider other)
    {
        _renderer = other.gameObject.GetComponent<SpriteRenderer>();
        _animator = other.gameObject.GetComponent<Animator>();

        if (other.CompareTag("Player") && this.tag == "MemoryPiece")
        {
            memoryPieceScript.TriggerDialouge();
        }
       
    }
}
