using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private Transform _spawns;
    [SerializeField] private Coin _coin;

    private Transform[] _spawnCoins;

    void Start()
    {
        _spawnCoins = new Transform[_spawns.childCount];
        AddCoin();
    }

    private void AddCoin()
    {
        for (int i = 0; i < _spawns.childCount; i++)
        {
            _spawnCoins[i] = _spawns.GetChild(i);
            Instantiate(_coin, _spawnCoins[i].position, Quaternion.identity);
        }
    }
}
