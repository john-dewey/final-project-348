using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void playGame()
   {
        Main.RESET_GRAVITY();
        SceneManager.LoadScene(1);
   }

   public void quitGame()
   {
        SceneManager.LoadScene(3);
   }

   public void menu()
   {
        SceneManager.LoadScene(0);
   }
}
