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

    public void Mode()
    {
        SceneManager.LoadScene("Mode");
    }
    public void Level_1()
    {
        SceneManager.LoadScene("Level_1");
    }


}
