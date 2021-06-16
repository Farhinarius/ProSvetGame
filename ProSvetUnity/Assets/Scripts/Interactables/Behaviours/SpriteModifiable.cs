using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteModifiable : Clickable
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite _originalSprite;
    [SerializeField] private Sprite _newSprite;

    protected override void Start()
    {
        base.Start();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnPointerButtonClick()
    {
        base.OnPointerButtonClick();
        SwitchSprite();
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
        _spriteRenderer.sprite = _turnedOn ? _newSprite : _originalSprite;
}
