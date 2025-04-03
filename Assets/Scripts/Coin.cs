using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;

    private void OnTriggerEnter(Collider other)
    {
        Wallet wallet = other.GetComponent<Wallet>();

        if (wallet != null)
        {
            wallet.AddCoins(_value);
            wallet.PrintBalance();

            gameObject.SetActive(false);
        }
    }

    public int Value => _value;
}
