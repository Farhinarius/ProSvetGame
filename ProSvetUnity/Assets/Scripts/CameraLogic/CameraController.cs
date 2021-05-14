using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float _speed;
    private Vector3 _camMovement;
    [SerializeField] CameraBounds2D bounds;
    Vector2 maxXPositions, maxYPositions;
    
    
    private void Awake()
    {
        bounds.Initialize(Camera.main.GetComponent<Camera>());
        maxXPositions = bounds.maxXlimit;
        maxYPositions = bounds.maxYlimit;
    }

    private void Start()
    {
        _camMovement = Vector3.zero;
        _transform = transform;
    }

    private void GetCameraMovement()
    {
        _camMovement.x = Input.GetAxis("Horizontal");
        _camMovement.y = Input.GetAxis("Vertical");
    }

    private void HandleCameraMovement()
    {
        var nextPos = _transform.position +_camMovement * _speed * Time.fixedDeltaTime;
        _transform.position = new Vector2(Mathf.Clamp(nextPos.x, maxXPositions.x, maxXPositions.y), Mathf.Clamp(nextPos.y, maxYPositions.x, maxYPositions.y));
    }

    private void Update()
    {
        GetCameraMovement();
    }

    private void FixedUpdate()
    {
        HandleCameraMovement();
    }
}
