using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public GameObject gameOverCutscene;

    [SerializeField]
    private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // change light from green to red
            var rend = GetComponent<MeshRenderer>();

            var color = new Color(.9059f, .5098f, .4745f, 0.25f);
            rend.material.SetColor("_TintColor", color);
            _animator.enabled = false;
            StartCoroutine(AlertRoutine());
        }

        IEnumerator AlertRoutine()
        {
            yield return new WaitForSeconds(.5f);
            gameOverCutscene.SetActive(true);
        }
    }
}
