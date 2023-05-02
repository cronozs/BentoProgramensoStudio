using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class showPoints : MonoBehaviour
{
    public float points = 0;
    public Text Puntaje;

    public void addScore(float add)
    {
        points += add;
        Puntaje.text = points.ToString();
    }
}
