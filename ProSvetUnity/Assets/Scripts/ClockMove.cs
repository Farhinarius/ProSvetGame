using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMove : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotMax;

    public void Update()
    {
        float rotDelta = rotationSpeed * Time.deltaTime;
        gameObject.transform.Rotate(0, 0, rotDelta);

        if (gameObject.transform.rotation.z <= rotMax)
        {
            rotationSpeed = 0;
        }
    }

}
