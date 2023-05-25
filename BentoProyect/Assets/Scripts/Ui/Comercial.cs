using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Comercial : MonoBehaviour
{
    public GameObject ad;
    public GameObject scorescreen;
    public GameObject gameOver;
    public GameObject timer;
    public GameObject puntaje;
    public GameObject loadingScreen;
    public GameObject MScreen;
    public Slider slider;
    public GameObject offButton;
    
   
    public void playAd()
    {
        showPoints.instance.extraScore();
        ad.SetActive(true);
        gameOver.SetActive(false);
        timer.SetActive(false);
        puntaje.SetActive(false);
        offButton.SetActive(true);
   

    }

    public void returnMenu()
    {
        scorescreen.SetActive(true);
        gameOver.gameObject.SetActive(false);
        timer.SetActive(false);
        puntaje.SetActive(false);
    }

    public void closeAd()
    {
        ad.gameObject.SetActive(false);
        scorescreen.gameObject.SetActive(true);
        timer.SetActive(false);
        puntaje.SetActive(true);
    }

    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        MScreen.SetActive(false);
        loadingScreen.SetActive(true);
        //yield return new WaitForSeconds(1);
        Debug.Log("cargando");
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
      
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
    
}
