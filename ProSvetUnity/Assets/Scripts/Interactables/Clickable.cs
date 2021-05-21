using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : Interactable
{
    public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite originalSprite;
    [SerializeField] public Sprite newSprite;

    public bool toogler;

    public override void OnPointerButtonClick()
    {
        ChangeSprite(toogler ? originalSprite : newSprite);
        toogler = !toogler;
    }

    public override void OnPointerButtonHold()
    {
        Debug.Log("Pointer Button Hold: " + _name);
    }

    public override void OnPointerEnter()
    {
        Debug.Log("Poitner Enter: " + _name);
    }

    public override void OnPointerExit()
    {
        Debug.Log("Pointer Exit: " + _name);
    }

    private void ChangeSprite(Sprite spriteToChange)
    {
        spriteRenderer.sprite = spriteToChange;
    }

}
