using System.Reflection;
using System.Collections;
using UnityEngine;

public class Movable : Interactable
{
    private Vector2 _initialPosition;
    private static bool _locked;
    private float _deltaX, _deltaY;

    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
    }

    public override void OnPointerButtonClick()
    {
        base.OnPointerButtonClick();
    }

    public override void OnPointerButtonHold()
    {
        base.OnPointerButtonHold();
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
    }

    // void OnMouseDrag()
    // {
    //     Debug.Log("OnMouseDrag");
    //     transform.position = PointerHandler.MouseTarget;
    // }
}
