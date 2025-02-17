﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Helpers;

public class HumanActions : MonoBehaviour
{
    #region Data

    // State Machine behaviour
    

    // timers
    public const float changeTime = 10f;
    public const float debugTime = 5f;
    [SerializeField] protected float timer;
    protected int direction = 1;

    // current transform
    protected Transform _transform;

    // physics
    public float _speed;
    protected Rigidbody2D _rb2d;
    
    // sprite changing logic
    public bool _turnedOn;
    private SpriteRenderer _spriteRenderer;
    private Sprite _originalSprite;
    [SerializeField] private Sprite[] _states;

    // level data
    protected LevelData LevelInfo { get; private set; }
    
    // personal info
    protected bool isDissatisfied;

    // emotion in future ???

   
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

    protected IEnumerator MoveTo(Transform target)
    {
        while (!Reached(_transform, target))
        {
            yield return new WaitForEndOfFrame();
            _transform.position = Vector2.MoveTowards(_transform.position, target.position, _speed * Time.deltaTime);
        }
    }

    public IEnumerator WaitMoveTo(Transform destination)
    {
        yield return StartCoroutine(MoveTo(destination));
    }

    protected void ChangeSprite(Sprite spriteToChange) =>
        _spriteRenderer.sprite = _turnedOn ? spriteToChange : _originalSprite;

    #endregion
}
