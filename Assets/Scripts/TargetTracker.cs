using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracker : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        transform.position = _target.position;

        transform.position += _offset;
    }
}
