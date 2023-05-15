using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Comercial : MonoBehaviour
{
    public GameObject ad;
    public GameObject scorescreen;
    public GameObject gameOver;
    
   
    public void playAd()
    {
        showPoints.instance.extraScore();
        ad.SetActive(true);
        gameOver.SetActive(false);
    }

    public void returnMenu()
    {
        scorescreen.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

    public void closeAd()
    {
        ad.gameObject.SetActive(false);
        scorescreen.gameObject.SetActive(true);
    }

    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}