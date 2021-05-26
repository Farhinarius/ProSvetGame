using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigable : Interactable
{
    public static event Action<Transform, Navigable> onRoomTargetChanged;

    public override void OnPointerButtonClick()
    {
        base.OnPointerButtonClick();
        onRoomTargetChanged?.Invoke(this.transform, this);         // change current target to this (camera movement logic)
    }

    public override void OnPointerButtonHold()
    {
        base.OnPointerButtonHold();
    }

    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
        GetComponent<SpriteRenderer>().color = Color.yellow;       // stay mock implementation, later change sprite to highlighted
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
        GetComponent<SpriteRenderer>().color = Color.white;        // stay mock implementation, later change sprite to default
    }
}