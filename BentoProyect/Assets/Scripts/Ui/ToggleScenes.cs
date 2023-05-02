using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class ToggleScenes : MonoBehaviour
{
    
   public void RandomGameplay()
    {
        SceneManager.LoadScene("PlayScene");
    }
    
   public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void Settings()
   {
       SceneManager.LoadScene("Settings");
   }

    public void Level_1()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void Level_2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void Level_3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void Level_4()
    {
        SceneManager.LoadScene("Level_4");
    }
    public void Level_5()
    {
        SceneManager.LoadScene("Level_5");
    }



}
