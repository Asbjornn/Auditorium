using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerVolume : MonoBehaviour
{
    public AudioMixer myMixer;
    public string propertyName;

    public void SetVolume(float volume)
    {
        float decibel = Mathf.Log10(volume) * 20f;
        myMixer.SetFloat(propertyName, decibel);
    }
}
