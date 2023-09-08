using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCollectingTrigger : MonoBehaviour
{
    [SerializeField] private int _numberCoins;

    private List<Coin> _coins = new List<Coin>();

    private void OnDisable()
    {
        foreach (Coin coin in _coins) 
        {
            coin.Collected -= OnCollected;
        }
    }

    public void Init(Coin coin)
    {
        coin.Collected += OnCollected;
        _coins.Add(coin);
    }

    private void OnCollected(Coin coin)
    {
        _numberCoins++;
        _coins.Remove(coin);
    }

}
