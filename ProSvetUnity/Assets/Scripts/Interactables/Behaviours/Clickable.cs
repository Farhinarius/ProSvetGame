using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : InteractableItem
{
    public bool _turnedOn;

    protected override void Start()
    {
        base.Start();
    }

    public override void OnPointerButtonClick()
    {
        base.OnPointerButtonClick();
        Switch();
    }

    public override void OnPointerButtonHold()
    {
        base.OnPointerButtonHold();
    }

    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
    }

    protected void Switch()
    {
        _turnedOn = !_turnedOn;
    }

}
