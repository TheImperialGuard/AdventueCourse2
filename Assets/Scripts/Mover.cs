using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    internal void Move(Vector3 direction)
    {
        Vector3 force = direction * _speed * Time.deltaTime;
        _rigidbody.AddForce(force, ForceMode.Force);
    }
}
