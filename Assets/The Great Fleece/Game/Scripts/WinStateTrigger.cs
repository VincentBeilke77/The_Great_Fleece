using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _levelCompleteCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.HasCard)
            {
                _levelCompleteCutscene.SetActive(true);
            }
        }
    }
}
