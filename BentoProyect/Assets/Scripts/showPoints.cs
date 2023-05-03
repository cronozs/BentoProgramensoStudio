using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class showPoints : MonoBehaviour
{
    public static showPoints instance;
    public float points = 0;
    public Text Puntaje;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Puntaje.text =  points.ToString();
    }

    public void addScore()
    {
        points += 1;
        Puntaje.text = points.ToString();
    }
}
