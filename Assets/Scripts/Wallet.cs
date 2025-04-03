using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _balance;

    public int Balance => _balance;

    public void AddCoins(int value)
    {
        if (value > 0) 
            _balance += value;
    }

    public void PrintBalance()
    {
        Debug.Log("Your coins: " + _balance);
    }
}
