using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interactable
{
    public bool turnedOn;
    public Lamp otherLamp;

    public SpriteRenderer spriteRendererOrigin;
    public SpriteRenderer spriteRendererOther;
    

    protected override void Start()
    {
        base.Start();
    }

    
    public override void OnPointerEnter()
    {
        // base.OnPointerEnter();
    }

    public override void OnPointerButtonClick()
    {
        // base.OnPointerButtonClick();
        ChangeSprites();
    }

    public override void OnPointerButtonHold()
    {
        base.OnPointerButtonHold();
    }

    public override void OnPointerExit()
    {
        // base.OnPointerExit();
    }

    private void ChangeSprites()
    {
        var temp = spriteRendererOrigin.sprite;
        spriteRendererOrigin.sprite = spriteRendererOther.sprite;
        spriteRendererOther.sprite = temp;

        turnedOn = !turnedOn;
        otherLamp.turnedOn = !otherLamp.turnedOn;
    }

}
