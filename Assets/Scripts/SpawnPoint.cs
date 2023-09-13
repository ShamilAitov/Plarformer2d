using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private Transform _spawns;
    [SerializeField] private Coin _prefab;
    [SerializeField] private Wallet _wallet;

    private Transform[] _spawnCoins;

    private void Start()
    {
        _spawnCoins = new Transform[_spawns.childCount];
        CreateCoins();
    }

    private void CreateCoins()
    {
        for (int i = 0; i < _spawns.childCount; i++)
        {
            _spawnCoins[i] = _spawns.GetChild(i);
            Coin coin = Instantiate(_prefab, _spawnCoins[i].position, Quaternion.identity);
            _wallet.GetCoin(coin);
        }
    }
}
