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
    public ParticleSystem winPs;
    public AudioSource Yippe;
    public AudioSource Enojada;
    public float monacambio=1;

    private void Start()
    {
        winPs.Stop();
    }

    private void Update()
    {
        if (lose.gameObject.activeInHierarchy)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = enojada;
            StartCoroutine(Default(Enojada));
            //Enojada.Play();

        }

        if (win.gameObject.activeInHierarchy)
        {
            winPs.Play();
            gameObject.GetComponent<SpriteRenderer>().sprite = feliz;
            StartCoroutine(Default(Yippe));
            //Yippe.Play();

        }

    }

    IEnumerator Default(AudioSource sonido)
    {
        if (!sonido.isPlaying)
        {
            sonido.Play();
        }
        yield return new WaitForSeconds(monacambio);
        gameObject.GetComponent<SpriteRenderer>().sprite = normal;
    }
}
