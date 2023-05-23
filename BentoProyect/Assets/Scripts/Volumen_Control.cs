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
        Mixer.SetFloat("BGM", Mathf.Log10(sliderVal)*20);
    }
    
    public void AudioV(float sliderVal)
    {
        Mixer.SetFloat("VFX", Mathf.Log10(sliderVal)*20);
    }
}
