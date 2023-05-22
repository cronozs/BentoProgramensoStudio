using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Volumen_Control : MonoBehaviour
{
    public AudioMixer Mixer;

    public void Audio(float sliderVal)
    {
        Mixer.SetFloat("Vol", Mathf.Log10(sliderVal)*20);
    }
}
