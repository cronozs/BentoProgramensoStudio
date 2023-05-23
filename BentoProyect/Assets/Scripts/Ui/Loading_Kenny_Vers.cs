using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_Kenny_Vers : MonoBehaviour
{
   public GameObject loadingScreen;
   public GameObject MScreen;
   public Slider slider; 
   
   
   public void LoadLevel(int sceneIndex)
   {
      StartCoroutine(LoadAsync(sceneIndex));
   }

   IEnumerator LoadAsync(int sceneIndex)
   {
      MScreen.SetActive(false);
      loadingScreen.SetActive(true);
      Debug.Log("wait");
      //yield return new WaitForSeconds(1);
      Debug.Log("cargando");
      AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
      Debug.Log("este boton si sirve");
      
      while (!operation.isDone)
      {
         float progress = Mathf.Clamp01(operation.progress / .9f);
         slider.value = progress;
         yield return null;
      }
   }
}
