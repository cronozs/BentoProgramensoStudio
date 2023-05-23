
using System;
using Unity.VisualScripting;
using UnityEngine;


public class ToggleScenes : MonoBehaviour
{
    [SerializeField] public GameObject lastCanvas;

    public void LastCanvas()
    {
        lastCanvas.SetActive(true);
    }
}
