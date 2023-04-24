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
      AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
      MScreen.SetActive(false);
      loadingScreen.SetActive(true);
      while (!operation.isDone)
      {
         float progress = Mathf.Clamp01(operation.progress / .9f);
         slider.value = progress;
         yield return null;
      }
   }
}
