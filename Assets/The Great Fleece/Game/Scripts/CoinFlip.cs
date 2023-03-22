using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlip : MonoBehaviour
{
    [SerializeField]
    private AudioClip _coinDrop;

    private void Start()
    {
        AudioManager.Instance.PlayCoinFlip(_coinDrop);
    }
}
