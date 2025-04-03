using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destructEffect;

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
            Destruct();
    }

    private void Destruct()
    {
        _destructEffect.transform.position = transform.position;
        _destructEffect.Play();

        gameObject.SetActive(false);
    }
}
