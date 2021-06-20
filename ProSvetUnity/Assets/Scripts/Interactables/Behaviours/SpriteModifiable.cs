using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteModifiable : Clickable
{
    [SerializeField] private Sprite _originalSprite;
    [SerializeField] private Sprite _newSprite;

    protected override void Start()
    {
        base.Start();
    }

    public override void OnPointerButtonClick()
    {
        SwitchSprite();
        base.OnPointerButtonClick();
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

    public void SwitchSprite() =>
        _spriteRenderer.sprite = _turnedOn ? _originalSprite : _newSprite;
}
