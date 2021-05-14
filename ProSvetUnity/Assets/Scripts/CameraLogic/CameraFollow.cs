using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // add camera restrictions

    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpSpeed;
    [SerializeField] private float _zoomSpeed;


    private Camera _innerCam;

    
    
    private void Start()
    {
        _innerCam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        var positionToMove = Vector2.Lerp(transform.position, _target.position, _lerpSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(positionToMove.x, positionToMove.y, transform.position.z);
    }

    private void Update()
    {
        ListenZoom();
    }

    private void ListenZoom()
    {
        float size = _innerCam.orthographicSize;
        
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            size -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
            size = Mathf.Clamp(size, 1, 15);
        }
        
        _innerCam.orthographicSize = size;
    }
}
