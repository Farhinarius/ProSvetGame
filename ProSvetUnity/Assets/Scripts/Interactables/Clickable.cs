using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : Interactable
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] public Sprite originalSprite;
    [SerializeField] public Sprite newSprite;

    public bool toogler;

    protected override void Start()
    {
        base.Start();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnPointerButtonClick()
    {
        base.OnPointerButtonClick();
        ChangeSprite(toogler ? originalSprite : newSprite);
        toogler = !toogler;
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

    private void ChangeSprite(Sprite spriteToChange) => 
        _spriteRenderer.sprite = spriteToChange;

}
