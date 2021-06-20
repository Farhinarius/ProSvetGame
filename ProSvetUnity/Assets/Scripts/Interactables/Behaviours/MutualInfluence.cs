using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutualInfluence : Connected
{
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
        SwapSprites();
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

    protected void SwapSprites()
    {
        var temp = _spriteRendererOrigin.sprite;
        _spriteRendererOrigin.sprite = _spriteRendererOther.sprite;
        _spriteRendererOther.sprite = temp;
    }

}
