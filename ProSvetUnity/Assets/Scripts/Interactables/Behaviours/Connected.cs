using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connected : Clickable
{
    public Connected _mutualItem;

    protected override void Start()
    {
        base.Start();
    }

    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
    }

    public override void OnPointerButtonClick()
    {
        base.OnPointerButtonClick();
        SwitchMutual();
    }

    public override void OnPointerButtonHold()
    {
        base.OnPointerButtonHold();
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
    }

    protected void SwitchMutual()
    {
        _mutualItem._turnedOn = !_mutualItem._turnedOn;
    }
}
