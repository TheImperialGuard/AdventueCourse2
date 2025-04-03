using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private bool _isGrounded;

    private void OnCollisionStay(Collision collision)
    {
        Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();

        if (obstacle != null )
            _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }

    public bool IsGrounded => _isGrounded;
}
