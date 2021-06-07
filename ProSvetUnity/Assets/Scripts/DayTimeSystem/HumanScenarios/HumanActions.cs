using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class HumanActions : MonoBehaviour
{
    // timer zone
    public const float changeTime = 2.5f;

    int direction = 1;

    float timer;

    // night event system
    private NightEventSystem _nightEventSystem;

    protected Transform _transform;

    protected Transform _target;

    protected float _speed;

    protected Rigidbody2D _rb2d;

    # region MonoBehaviour Methods

    protected virtual void Start()
    {
        _nightEventSystem = GameObject.Find("TimeOfDay/NightEventSystem").GetComponent<NightEventSystem>() ?? throw new NullReferenceException("Not initialized night event system");
        _transform = transform;
    }

    # endregion

    # region Methods

    protected void UpdateMove() =>
        _transform.position = Vector2.MoveTowards(_transform.position, _target.position, _speed * Time.fixedDeltaTime);

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


    #endregion
}
