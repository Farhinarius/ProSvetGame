using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class HumanActions : MonoBehaviour
{
    #region Data

    public const float changeTime = 10f;
    public const float debugTime = 5f;
    [SerializeField] protected float timer;
    protected int direction = 1;

    protected Transform _transform;
    protected Transform _target;

    public float _speed;
    protected Rigidbody2D _rb2d;

    protected LevelData LevelInfo { get; private set; }

    public bool _turnedOn;
    private SpriteRenderer _spriteRenderer;
    private Sprite _originalSprite;
    
    [SerializeField] private Sprite[] _states;

    # endregion

    # region MonoBehaviour Methods

    protected virtual void Start()
    {
        LevelInfo = GameObject.Find("TimeOfDay/NightEventSystem").GetComponent<NightEventSystem>().LevelInfo
                                                ?? throw new NullReferenceException("Level data not found");
        _transform = transform;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalSprite = _spriteRenderer.sprite;

    }

    # endregion

    # region Methods

    protected void UpdateMove() =>
        _transform.position = Vector2.MoveTowards(_transform.position, _target.position, _speed * Time.deltaTime);

    protected void WalkAround()
    {
        timer -= Time.fixedDeltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 objPos = _rb2d.position;
        objPos.x += _speed * Time.fixedDeltaTime * direction;
        _rb2d.MovePosition(objPos);
    }

    protected void SetDestination(Transform target) =>
        _target = target;

    protected void ChangeSprite(Sprite spriteToChange) =>
        _spriteRenderer.sprite = _turnedOn ? spriteToChange : _originalSprite; 

    #endregion
}
