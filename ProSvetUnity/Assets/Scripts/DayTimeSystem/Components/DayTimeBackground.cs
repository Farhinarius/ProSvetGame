using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeBackground : MonoBehaviour
{
    [SerializeField] public Sprite[] _timesOfDay = new Sprite[3];

    [SerializeField] public int dayTimeNum;

    private void Awake()
    {
        TimeOfDay.onTimeOfDayChange += ChangeBackground;
    }
    
    public void ChangeBackground(TimeOfDay.States state, TimeOfDay timeOfDay) =>
        gameObject.GetComponent<SpriteRenderer>().sprite = _timesOfDay[ (int) state ];

}