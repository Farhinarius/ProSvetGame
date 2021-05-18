
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeBackground : MonoBehaviour
{
    [SerializeField] public Sprite[] timesOfDay = new Sprite[3];

    [SerializeField] public int dayTimeNum;

    private void Awake()
    {
        DayTimeChangingStateMachine.onBackgroundChange += ChangeBackground;
    }
    
    public void ChangeBackground(int value, DayTimeChangingStateMachine dayTimeChangeSM)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = timesOfDay[value];
        Debug.Log("BG has changed");
    }

}