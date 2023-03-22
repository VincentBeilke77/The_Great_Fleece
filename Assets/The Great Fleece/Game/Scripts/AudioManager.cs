using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioManager _instance;
    public AudioManager Instance 
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

    private void Awake()
    {
        _instance = this;
    }
}
