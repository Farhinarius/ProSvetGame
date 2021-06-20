using System;
using UnityEngine;

[System.Serializable]
public class InteractableItem : Interactable
{
    public static event Action OnMouseEnterCallback;
    public static event Action OnMouseButtonCallback;
    public static event Action OnMouseExitCallback;

    protected SpriteRenderer _spriteRenderer;
    
    protected override void Start()
    {
        base.Start();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.white;
    }
    
    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
        _spriteRenderer.color = Color.yellow;
    }

    public override void OnPointerButtonClick()
    {
        OnMouseButtonCallback?.Invoke();
        base.OnPointerButtonClick();
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
        _spriteRenderer.color = Color.white;
    }
}
