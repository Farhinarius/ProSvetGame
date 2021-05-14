
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeBackground : MonoBehaviour
{
    [SerializeField] public Sprite[] timesOfDay = new Sprite[3];

    [SerializeField] public int dayTimeNum;

    public void Update()
    {

        gameObject.GetComponent<SpriteRenderer>().sprite = timesOfDay[dayTimeNum];

    }

}