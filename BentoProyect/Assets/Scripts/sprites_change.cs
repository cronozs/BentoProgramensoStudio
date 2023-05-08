using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprites_change : MonoBehaviour
{
    public Sprite enojada;
    public Sprite normal;
    public Sprite feliz;
    public Canvas lose;
    public Canvas win;
    
    private void Update()
    {
        if (lose.isActiveAndEnabled)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = enojada;
            StartCoroutine(Default());

        }

        if (win.isActiveAndEnabled)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = feliz;
            StartCoroutine(Default());
            
        }

    }

    IEnumerator Default()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("cambio");
        gameObject.GetComponent<SpriteRenderer>().sprite = normal;
    }
}
