using UnityEngine;
using MonsterLove.StateMachine;
using System;

public class GirlActions : HumanActions
{
    public enum States
    {
        Null,
        Rest,
        WalkAround,
        MovingToDestination,
        Sleep
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
    }


}