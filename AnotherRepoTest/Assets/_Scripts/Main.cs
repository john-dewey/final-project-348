using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Main : MonoBehaviour
{
    static private Main S;
    public float gameRestartDelay = 2;

    void Awake()
    {
        S = this;
    }

    void DelayedRestart()
    {                                                  
        Invoke(nameof(Restart), gameRestartDelay);
    }

    void Restart()
    {
        SceneManager.LoadScene("Obstacle");                         
    }

    static public void HERO_DIED()
    {
        S.DelayedRestart();                                                  
    }
}
