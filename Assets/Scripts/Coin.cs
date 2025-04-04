using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;

    [SerializeField] private CoinsResolver _coinsResolver;
    [SerializeField] private ParticleSystem _collectEffect;

    private void OnTriggerEnter(Collider other)
    {
        Wallet wallet = other.GetComponent<Wallet>();

        if (wallet != null)
        {
            Collect();
            AddTo(wallet);
        }
    }

    public int Value => _value;

    private void Collect()
    {
        _coinsResolver.Collect();
        _coinsResolver.PrintProgress();
    }

    private void AddTo(Wallet wallet)
    {
        wallet.AddCoins(_value);
        wallet.PrintBalance();

        _collectEffect.transform.position = transform.position;
        _collectEffect.Play();

        gameObject.SetActive(false);
    }
}
