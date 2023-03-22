using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _sleepingGuardCutscene;
    [SerializeField]
    private GameObject _camera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _sleepingGuardCutscene.SetActive(true);
            GameManager.Instance.HasCard = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _sleepingGuardCutscene.SetActive(false);
        }
    }
}
