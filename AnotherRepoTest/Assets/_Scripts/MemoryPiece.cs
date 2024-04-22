using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPiece : MonoBehaviour
{
    public Dialouge dialouge;
    public void TriggerDialouge()
    {
        FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
    }
}
