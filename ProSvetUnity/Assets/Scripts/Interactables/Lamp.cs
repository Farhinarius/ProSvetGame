using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : InteractableItem
{
    public bool turnedOn;
    public Lamp _otherLamp;

    public SpriteRenderer _spriteRendererOrigin;
    public SpriteRenderer _spriteRendererOther;


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
        SwapSprites();
    }

    public override void OnPointerButtonHold()
    {
        base.OnPointerButtonHold();
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
    }

    private void SwapSprites()
    {
        var temp = _spriteRendererOrigin.sprite;
        _spriteRendererOrigin.sprite = _spriteRendererOther.sprite;
        _spriteRendererOther.sprite = temp;

        turnedOn = !turnedOn;
        _otherLamp.turnedOn = !_otherLamp.turnedOn;
    }

}
