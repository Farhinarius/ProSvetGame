using UnityEngine;
using MonsterLove.StateMachine;
using System;

public class GirlActions : HumanActions
{
    public enum State
    {
        Null,
        Rest,
        WalkAround,
        MovingToDestination,
        Sleep
    }

    StateMachine<State, Driver> _fsm;

    public State CurrentState { get; private set; }

    private void Awake()
    {
        _fsm = new StateMachine<State, Driver>(this);
    }

    protected override void Start()
    {
        _fsm.Changed += OnChangeState;
        base.Start();
    }

    private void OnChangeState(State state) => 
        CurrentState = _fsm.State;


}