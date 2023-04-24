using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading_Kenny_Vers : MonoBehaviour
{
   public void LoadLevel(int sceneIndex)
   {
      StartCoroutine(LoadAsync(sceneIndex));
   }

   IEnumerator LoadAsync(int sceneIndex)
   {
      AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
      while (!operation.isDone)
      {
         float progress = Mathf.Clamp01(operation.progress / .9f);
         Debug.Log(progress.ToString());
         yield return null;
      }
   }
}
