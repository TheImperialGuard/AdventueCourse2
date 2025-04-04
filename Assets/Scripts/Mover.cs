using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 force = direction * _speed * Time.deltaTime;
        _rigidbody.AddForce(force, ForceMode.Force);
    }

    public void Jump()
    {
        Vector3 force = Vector3.up * _jumpForce * Time.deltaTime;
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }

    public void ResetMotion()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
