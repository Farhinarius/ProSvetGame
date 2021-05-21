using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interactable
{
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
        Debug.Log("Pointer Button Hold: " + _name);
    }

    public override void OnPointerExit()
    {
        Debug.Log("Pointer Exit: " + _name);
    }

}
