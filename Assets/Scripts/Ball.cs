using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]

public class Ball : MonoBehaviour
{
    private string VerticalAxis = "Vertical";
    private string HorizontalAxis = "Horizontal";

    private KeyCode _jumpKeyCode = KeyCode.Space;

    private Mover _mover;

    private Vector3 _input;

    private bool _isJumping;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        MotionInputProcessing();
        JumpInputProcessing();
    }

    private void FixedUpdate()
    {
        if (_isMoving)
            _mover.Move(_input);

        if (_isJumping)
        {
            _mover.Jump();

            _isJumping = false;
        }
    }

    private bool _isMoving => _input != Vector3.zero;

    private void MotionInputProcessing()
    {
        _input = new Vector3(Input.GetAxis(HorizontalAxis), 0, Input.GetAxis(VerticalAxis));
    }

    private void JumpInputProcessing()
    {
        if (Input.GetKeyDown(_jumpKeyCode))
            _isJumping = true;
    }
}
