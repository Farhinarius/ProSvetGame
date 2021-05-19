using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockMove : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private Transform _transform;

    private Quaternion _targetRotation;

    private float _direction = 1; 

    private bool rotating = true;

    private void Awake()
    {
        TimeOfDay.onTimeOfDayChange += SetUpNextAngle;
    }

    private void Start()
    {
        _transform = this.transform;
        _targetRotation = _transform.rotation;          // important to save rotations
    }

    private void Update()
    {
        RotateArrow();
    }

    private void RotateArrow()
    {
        if (rotating)
        {
            transform.rotation = Quaternion.Lerp(_transform.rotation, _targetRotation, Time.deltaTime);

            if ( Mathf.Abs(_targetRotation.z - _transform.rotation.z) < 0.01f )
                 rotating = false;
                
            Debug.Log(_transform.rotation.z);
        }

    }

    public void SetUpNextAngle(TimeOfDay.States timeOfDayState, TimeOfDay timeOfDay)
    {
        rotating = true;

        switch (timeOfDayState)
        {
            case TimeOfDay.States.Evening:
            {
                _targetRotation = Quaternion.Euler(0, 0, 70);
                break;
            }
            case TimeOfDay.States.Night:
            {
                _targetRotation = Quaternion.Euler(0, 0, 0);
                break;
            }
            case TimeOfDay.States.Morning:
            {
                _targetRotation = Quaternion.Euler(0, 0, -70);
                break;
            }
        }

        Debug.Log("transform z: " + _transform.rotation);
        Debug.Log("target z: " + _targetRotation);
    }

}
