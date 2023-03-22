using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    public AudioClip voiceOverClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayVoiceOver(voiceOverClip);
        }
    }
}
