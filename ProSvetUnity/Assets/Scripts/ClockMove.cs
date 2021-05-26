using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockMove : MonoBehaviour
{
    private Transform _transform;
    private Quaternion _targetRotation;

    [SerializeField] private float _rotationSpeed;
    private bool rotating = true;

    private void Start()
    {
        TimeOfDay.onTimeOfDayChange += SetUpNextClockAngle;     // transfet to awake method it didn't work
        _transform = this.transform;
        _targetRotation = _transform.rotation;          // important to save rotations
    }

    private void Update() => RotateArrow();


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

    public void SetUpNextClockAngle(TimeOfDay.States timeOfDayState, TimeOfDay timeOfDay)
    {
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

        rotating = true;
    }

}
