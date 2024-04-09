using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Main : MonoBehaviour
{
    static private Main _S;
    public float gameRestartDelay = 0.5f;

    void Awake()
    {
        _S = this;
    }

    void DelayedRestart()
    {                                                  
        Invoke(nameof(Restart), gameRestartDelay);
    }

    void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);                         
    }

    public static void HERO_DIED()
    {
        GravityController.resetGravity();
        _S.DelayedRestart();                                               
    }
}
