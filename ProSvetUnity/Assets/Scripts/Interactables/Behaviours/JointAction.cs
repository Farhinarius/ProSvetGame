using UnityEngine;

public class JointAction : Connected
{
    private Sprite _origin;
    [SerializeField] private Sprite _spriteUpdate;
    private JointAction _mutualObj;
    public static event System.Action AudioCallbackForButtonClick;

    protected override void Start()
    {
        base.Start();
        _origin = _spriteRenderer.sprite;
        _mutualObj = (JointAction) _mutualItem;
    }

    public override void OnPointerButtonClick()
    {
        this.UpdateSprite();
        _mutualObj.UpdateSprite();
        
        AudioCallbackForButtonClick.Invoke();
        base.OnPointerButtonClick();
    }

    private void UpdateSprite() =>
        _spriteRenderer.sprite = _turnedOn ? _spriteUpdate : _origin;
}
