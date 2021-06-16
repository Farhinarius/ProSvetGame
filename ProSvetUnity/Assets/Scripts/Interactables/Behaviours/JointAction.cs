using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointAction : Connected
{
    private SpriteRenderer _spriteRenderer;
    private Sprite _origin;
    [SerializeField] private Sprite _spriteUpdate;
    private JointAction _mutualObj;

    protected override void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _origin = _spriteRenderer.sprite;
        _mutualObj = (JointAction) _mutualItem;
    }

    public override void OnPointerButtonClick()
    {
        base.OnPointerButtonClick();
        this.UpdateSprite();
        _mutualObj.UpdateSprite();
    }

    private void UpdateSprite() =>
        _spriteRenderer.sprite = _turnedOn ? _spriteUpdate : _origin;
}
