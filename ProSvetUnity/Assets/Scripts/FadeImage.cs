using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeImage : Interactable
{
    public override void OnPointerButtonClick()
    {
        base.OnPointerButtonClick();
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<BoxCollider2D>());
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

}