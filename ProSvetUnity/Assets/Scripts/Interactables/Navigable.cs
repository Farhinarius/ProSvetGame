using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigable : MonoBehaviour, IClickable
{
    private string _name;
    public static event Action<Transform, Navigable> onRoomTargetChanged;

    private void Start()
    {
        _name = this.gameObject.name;
    }

    public void OnPointerButtonClick()
    {
        Debug.Log("Clicked on room: " + _name);
        onRoomTargetChanged?.Invoke(this.transform, this);         // change current target to this (camera movement logic)
    }

    public void OnPointerButtonHold()
    {
        Debug.Log("Pointer Button Hold: " + _name);
    }

    public void OnPointerEnter()
    {
        Debug.Log("Entered in room: " + _name);
        GetComponent<SpriteRenderer>().color = Color.yellow;       // stay mock implementation, later change sprite to highlighted
    }

    public void OnPointerExit()
    {
        Debug.Log("Exit from room: " + _name);
        GetComponent<SpriteRenderer>().color = Color.white;        // stay mock implementation, later change sprite to default
    }
}