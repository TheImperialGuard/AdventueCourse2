using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;

    [SerializeField] private ParticleSystem _collectEffect;

    private void OnTriggerEnter(Collider other)
    {
        Wallet wallet = other.GetComponent<Wallet>();

        if (wallet != null)
        {
            AddTo(wallet);
        }
    }

    public int Value => _value;

    private void AddTo(Wallet wallet)
    {
        wallet.AddCoins(_value);
        wallet.PrintBalance();

        _collectEffect.transform.position = transform.position;
        _collectEffect.Play();

        gameObject.SetActive(false);
    }
}
