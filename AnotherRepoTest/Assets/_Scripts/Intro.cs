using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    // Reference to the MemoryPiece script
    public MemoryPiece memoryPieceScript;

    // Start is called before the first frame update
    void Start()
    {
        
        memoryPieceScript.TriggerDialouge();
        
    }
}
