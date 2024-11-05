using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class Victory : MonoBehaviour
{
    [Header("MusicBox Script")]
    public GameObject[] musicBox;
    public List<MusicBox> musicBoxScript;

    [Header("Parameters")]
    public float timeWithFullVolume;
    public float chrono = 0f;

    [Header("Animator")]
    public Animator animator;

    [Header("Event")]
    public GameEvent victoryEvent;

    // Start is called before the first frame update
    void Start()
    {
        musicBox = GameObject.FindGameObjectsWithTag("MusicBox");
        for (int i = 0; i < musicBox.Length; i++)
        {
            print("je lis");
            musicBoxScript.Add(musicBox[i].GetComponent<MusicBox>());
        };
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (var musicBox in musicBoxScript)
        {
            if (musicBox.audioSource.volume >= 1)
            {
                if (chrono >= timeWithFullVolume)
                {
                    musicBox.volumeAtMax = true;
                }
                else if (musicBox.audioSource.volume < 1)
                {
                    musicBox.volumeAtMax = false;
                }
                else
                {
                    chrono += Time.deltaTime;
                }
            }
        }*/
        if (AllVolumeAtMax())
        {
            Debug.Log("Tous les AudioSources ont leur volume à 1");
            if(chrono > timeWithFullVolume)
            {
                EndOfLevel();
            }
            else
            {
                chrono += Time.deltaTime;
            }
        }
        else
        {
            chrono = 0f;
            Debug.Log("Tous les AudioSources n'ont pas encore leur volume à 1");
        }
    }

    public void EndOfLevel()
    {
        victoryEvent.Trigger();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    bool AllVolumeAtMax()
    {
        foreach (var musicBox in musicBoxScript)
        {
            if (musicBox.audioSource.volume != 1)
            {
                return false;
            }
        }

        return true;
    }
}
