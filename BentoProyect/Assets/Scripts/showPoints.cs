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
    public Text Final;
    public GameObject boton;
    [SerializeField] private IngredientList multy;

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if (points < 10)
        {
            
            boton.SetActive(false);
        }
        else
        {
            boton.SetActive(true);
        }
    }

    private void Start()
    {
        Puntaje.text = "$" +  points.ToString();
    }

    public void addScore()
    {
        multy = FindObjectOfType<IngredientList>();
        points += (multy.fill * 5);
        points = Mathf.Round(points * 10f) / 10f;
        Puntaje.text =  "$" + points.ToString();
        Final.text = "$" + points.ToString() + " en propinas";

    }

    public void extraScore()
    {
        points += 10;
        Final.text = "$" + points.ToString() + " en propinas";
    }
}
