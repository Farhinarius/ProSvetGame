﻿using System.Reflection;
using System.Collections;
using UnityEngine;

public class Movable : Interactable
{
    private Vector2 _initialPosition;
    private static bool _locked;
    private float _deltaX, _deltaY;

    public override void OnPointerEnter()
    {
        Debug.Log("Poitner Enter: " + _name);
    }

    public override void OnPointerButtonClick()
    {
        Debug.Log("Pointer Click: " + _name);
    }

    public override void OnPointerButtonHold()
    {
        
    }

    public override void OnPointerExit()
    {
        Debug.Log("Pointer Exit: " + _name);
    }

    // void OnMouseDrag()
    // {
    //     Debug.Log("OnMouseDrag");
    //     transform.position = PointerHandler.MouseTarget;
    // }
}
