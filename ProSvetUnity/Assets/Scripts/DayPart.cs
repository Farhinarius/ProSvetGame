using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayPart : MonoBehaviour
{
    [SerializeField] public Text[] parts = new Text[4];

    [SerializeField] public int partsNum;


    void Start()
    {
        //gameObject.GetComponent<Text>() = parts[skyNum];
    }

}
