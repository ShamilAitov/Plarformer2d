using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCollectingTrigger : MonoBehaviour
{
    [SerializeField] private int _numberCoins;

    public void OnCoinReached()
    {
        _numberCoins++;
    }
}
