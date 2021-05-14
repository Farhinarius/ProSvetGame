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

    public void OnPointerClick()
    {
        Debug.Log("Clicked on room: " + _name);
        onRoomTargetChanged?.Invoke(this.transform, this);         // change current target to this
    }

    public void OnPointerEnter()
    {
        Debug.Log("Entered in room: " + _name);
        GetComponent<BoxCollider2D>().enabled = false;             // non detectable by mouse
        GetComponent<SpriteRenderer>().color = Color.yellow;       // stay mock implementation, later change sprite to highlighted
    }

    public void OnPointerExit()
    {
        Debug.Log("Exit from room: " + _name);
        GetComponent<BoxCollider2D>().enabled = true;              // detectable by mouse
        GetComponent<SpriteRenderer>().color = Color.white;        // stay mock implementation, later change sprite to default
    }
}