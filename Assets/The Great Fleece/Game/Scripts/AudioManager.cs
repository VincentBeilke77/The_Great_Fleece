using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance 
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Audio Manager is NULL.");
            }

            return _instance;
        }
    }

    public AudioSource voiceOver;
    public AudioSource coinFlip;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clip)
    {
        if (clip != null)
        {
            voiceOver.clip = clip;
            voiceOver.Play();
        }
    }

    public void PlayCoinFlip(AudioClip clip)
    {
        if (clip != null)
        {
            coinFlip.clip = clip;
            coinFlip.Play();
        }
    }
}
