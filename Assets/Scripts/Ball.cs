using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]

public class Ball : MonoBehaviour
{
    private string VerticalAxis = "Vertical";
    private string HorizontalAxis = "Horizontal";

    private Mover _mover;

    private Vector3 _input;
    private bool _isMoving;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        _input = new Vector3(Input.GetAxis(HorizontalAxis), 0, Input.GetAxis(VerticalAxis));

        if (_input != Vector3.zero)
        {
            _isMoving = true;

            _input += Camera.main.transform.forward;
        }
        else
        {
            _isMoving = false;
        }
    }

    private void LateUpdate()
    {
        if (_isMoving)
            _mover.Move(_input);
    }
}
