using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class ToggleScenes : MonoBehaviour
{
    
   public void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
    
   public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   
   public void Settings()
   {
       SceneManager.LoadScene("Settings");
   }
    
}
