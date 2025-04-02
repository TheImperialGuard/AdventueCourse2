using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundRotator : MonoBehaviour
{
    [SerializeField] private Transform _aroundPoint;

    [SerializeField] private float _sensetivity;
    [SerializeField] private Vector3 _offset;

    private string HorizontalAxis = "Mouse X";

    private void Awake()
    {
        transform.position = _aroundPoint.position + _offset;
    }

    private void Update()
    {
        float input = Input.GetAxis(HorizontalAxis);

        transform.RotateAround(_aroundPoint.position, new Vector3(0, input, 0), _sensetivity * Time.deltaTime);
    }
}
