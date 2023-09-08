using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private Transform _spawns;
    [SerializeField] private Coin _coin;
    [SerializeField] private CoinCollectingTrigger _collectingTrigger;

    private Transform[] _spawnCoins;

    void Start()
    {
        _spawnCoins = new Transform[_spawns.childCount];
        CreateCoin();
    }

    private void CreateCoin()
    {
        for (int i = 0; i < _spawns.childCount; i++)
        {
            _spawnCoins[i] = _spawns.GetChild(i);
            Coin coin = Instantiate(_coin, _spawnCoins[i].position, Quaternion.identity);
            _collectingTrigger.Init(coin);
        }
    }
}
