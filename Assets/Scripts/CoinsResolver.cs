using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsResolver : MonoBehaviour
{
    [SerializeField] private List<GameObject> _coins;

    private int _collectedCoins;

    public bool IsAllCoinsCollected => _collectedCoins == CoinsCount;
    public int CoinsCount => _coins.Count;

    public void Collect()
    {
        _collectedCoins++;

        if (_collectedCoins >= CoinsCount)
        {
            _collectedCoins = CoinsCount;
        }
    }

    public void PrintProgress()
    {
        Debug.Log($"Collected coins: {_collectedCoins}/{CoinsCount}");
    }

    public void RespawnCoins()
    {
        foreach (GameObject coin in _coins)
        {
            coin.SetActive(true);
        }

        _collectedCoins = 0;
    }
}
