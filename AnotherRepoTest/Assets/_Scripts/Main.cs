using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Main : MonoBehaviour
{
    static private Main _S;
    public float gameRestartDelay = 0.5f;
    public float objectDeleteDelay = 0.1f;

    static private GameObject _object;

    void Awake()
    {
        _S = this;
    }

    void DelayedDelete()
    {                                                  
        Invoke(nameof(Delete), gameRestartDelay);
    }

    void Delete()
    {
        Destroy(_object);                      
    }

    public static void OBJECT_DELETE(GameObject gameObject)
    {
        _object = gameObject;
        _S.DelayedDelete();
    }

    void DelayedRestart()
    {                                                  
        Invoke(nameof(Restart), objectDeleteDelay);
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
