using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _lowerValue;
    [SerializeField] private int _upperValue;

    private int _value;

    private void Awake()
    {
        _value = Random.Range(_lowerValue, _upperValue + 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();

        if (ball != null)
        {
            //ball
            gameObject.SetActive(false);
        }
    }

    public int Value => _value;
}
