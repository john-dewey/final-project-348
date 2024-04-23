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
         bool loopExit = false;

        if (other.CompareTag("Player") && this.tag == "MemoryPiece")
        {
            memoryPieceScript.TriggerDialouge();
            loopExit = true;
        }

       
        Animator animator = DialougeBox.GetComponent<Animator>();
            
       while (loopExit == true)
       {
        // Get the value of the boolean parameter
        bool isOpen = animator.GetBool("IsOpen");
        Debug.Log("isOpen" + isOpen);
        if (isOpen == false)
        {
            levelLoader.LoadNextLevel();
            loopExit = false;
        } 
       }
    }
}
