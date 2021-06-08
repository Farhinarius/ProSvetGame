using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class HumanActions : MonoBehaviour
{
    // timer zone
    public const float changeTime = 2.5f;

    protected int direction = 1;

    protected float timer;

    // night event system
    protected NightEventSystem _nightEventSystem;

    protected Transform _transform;

    protected Transform _target;

    public float _speed;

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

    protected void ChangeDestination(Transform target) =>
        _target = target;

    protected bool ReachedOf(Transform target) =>
        _transform.position == _target.position;

    #endregion
}
