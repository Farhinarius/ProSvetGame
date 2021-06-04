using UnityEngine;
using MonsterLove.StateMachine;
using System;

public class GirlActions : HumanActions
{
    public enum States
    {
        DoNothing,
        Rest
    }

    StateMachine<States, Driver> _fsm;
    
    public States CurrentState { get => _fsm.State; }

    private void Awake()
    {
        _fsm = new StateMachine<States, Driver>(this);
    }

    protected override void Start()
    {
        base.Start();
        rb2d = GetComponentInParent<Rigidbody2D>();
        _fsm.ChangeState(States.DoNothing);
    }

    void DoNothing_Enter()
    {
        Debug.Log("Do Nothing" + transform.parent.name);
    }



    private void Update()
    {
        _fsm.Driver.Update.Invoke();
    }

    private void FixedUpdate()
    {
        _fsm.Driver.FixedUpdate.Invoke();
    }
}