using System;
using UnityEngine;

public class Navigable : Interactable
{
    public static event Action<Transform> onViewRoomChanged;

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
        base.OnPointerButtonClick();
        onViewRoomChanged?.Invoke(this.transform);         // change current target to this (camera movement logic)
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
        _spriteRenderer.color = Color.white;
    }
}