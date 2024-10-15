using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    [Header("Music & Colors")]
    public AudioSource audioSource;
    public Color noMusicColor;
    public Color musicColor;
    public SpriteRenderer[] musicList;


    [Header("Parameters")]
    public float addVolume = 0.02f;
    public float timeWithoutParticles = 2f;
    public float volumeReduction = 0.5f;

    private float chrono = 0f;
    private int numberOfParticles;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = 0;
        foreach (SpriteRenderer renderer in musicList)
        {
            renderer.color = noMusicColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBarColor();
        if(numberOfParticles == 0 && chrono >= timeWithoutParticles)
        {
            ResetVolume(volumeReduction);
        }
        else
        {
            chrono += Time.deltaTime;
        }
    }

    public void SetVolume(float value)
    {
        audioSource.volume += value;
    }

    public void ResetVolume(float volume)
    {
        audioSource.volume -= volume * Time.deltaTime;
    }

    public void UpdateBarColor()
    {
        for(int i = 0; i < musicList.Length; i++)
        {
            float step = i / (float) musicList.Length;
            if(audioSource.volume > step)
            {
                musicList[i].color = musicColor;
            }
            else
            {
                musicList[i].color = noMusicColor;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetVolume(addVolume);
        numberOfParticles++;
        chrono = 0f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        numberOfParticles--;
        if(numberOfParticles <= 0)
        {
            numberOfParticles = 0;
        }
    }
}
