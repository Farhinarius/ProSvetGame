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

    [SerializeField] protected float speed;

    public Dictionary<string, Transform> _associatedTargets;

    protected Rigidbody2D rb2d;

    #region MonoBehaviour Methods

    protected virtual void Start()
    {
        _nightEventSystem = GameObject.Find("TimeOfDay/NightEventSystem").GetComponent<NightEventSystem>() ?? throw new NullReferenceException("Not initialized night event system");
        _transform = transform;
        _associatedTargets = new Dictionary<string, Transform>();
    }

    # endregion

    # region Methods

    protected void SetTarget(string targetName) =>
        _target = _associatedTargets[targetName];

    protected void UpdateMove() =>
        _transform.position = Vector2.MoveTowards(_transform.position, _target.position, speed * Time.fixedDeltaTime);

    protected IEnumerator CoroutineMoveTo()
    {
        while (_transform.position != _target.position)
        {
            yield return new WaitForFixedUpdate();
            Vector2.MoveTowards(_transform.position, _target.position, Time.fixedDeltaTime);
        }
    }
    
    protected async void MoveToAsync()
    {
        await Task.Delay( (int) (Time.fixedDeltaTime  * 1000) );
        _transform.position =  Vector2.MoveTowards(_transform.position, _target.position, Time.fixedDeltaTime);
    }

    protected void WalkAround()
    {
        timer -= Time.fixedDeltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 objPos = rb2d.position;
        objPos.x += speed * Time.fixedDeltaTime * direction;
        rb2d.MovePosition(objPos);
    }


    #endregion
}
