using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;
using static Helpers;

public class WorkmanActions : HumanActions
{
    public enum States
    {
        Idle,
        CannotWork,
        MovingToDestination,
        Work,
        TakeAShower,
        Sleep
    }

    StateMachine<States, GeneralDriver> _fsm;

    public States CurrentState => _fsm.State;

    private bool lampIsTurnedOn =>
        LevelInfo.InteractableItems.lamp1.turnedOn;

    private bool lampIsTurnedOff =>
        !LevelInfo.InteractableItems.lamp1.turnedOn;

    private void Awake()
    {
        _fsm = new StateMachine<States, GeneralDriver>(this);
    }

    protected override void Start()
    {
        base.Start();
        _rb2d = GetComponentInParent<Rigidbody2D>();
        _fsm.ChangeState(States.CannotWork);
    }

    void CannotWork_Enter()
    {
        Debug.Log("Enter 'Cannot Work' state");
    }

    void CannotWork_Update()
    {
        if (lampIsTurnedOn)
            _fsm.ChangeState(States.MovingToDestination);
    }

    void CannotWork_Exit()
    {
        SetDestination(LevelInfo.Destinations.workPlace);
    }

    void MovingToDestination_Enter()
    {
        Debug.Log($"Enter MovingToDestination. Move To {_target}");
    }

    void MovingToDestination_FixedUpdate()
    {
        UpdateMove();

        if (Reached(_transform, _target))
        {
            if (_target == LevelInfo.Destinations.workPlace)
                _fsm.ChangeState(States.Work);
            else if (_target == LevelInfo.Destinations.workmanInitialPosition)
                _fsm.ChangeState(States.CannotWork);
            else if (_target == LevelInfo.Destinations.shower)
                _fsm.ChangeState(States.TakeAShower);
        }
    }

    void Work_Enter()
    {
        Debug.Log("Enter 'Work' state");
        timer = debugTime;
    }

    void Work_Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else if (lampIsTurnedOff || timer <= 0)
            _fsm.ChangeState(States.MovingToDestination);
    }

    void Work_Exit()
    {
        if (lampIsTurnedOff)
        {
            SetDestination(LevelInfo.Destinations.workmanInitialPosition);
            return;
        }

        SetDestination(LevelInfo.Destinations.shower);
    }

    void TakeAShower_Enter()
    {
        Debug.Log("Enter 'TakeAShower' state");
        timer = debugTime;
    }

    void TakeAShower_Update()
    {
        if (timer > 0) timer -= Time.deltaTime;

        else if (timer <= 0) 
            _fsm.ChangeState(States.MovingToDestination);
    }

    void TakeAShower_Exit()
    {
        SetDestination(LevelInfo.Destinations.workmanInitialPosition);
    }

    void Idle_Enter()
    {
        
    }


    # region StateMachine Driver Methods

    // Update is called once per frame
    private void Update()
    {
        _fsm.Driver.Update.Invoke();
    }

    private void FixedUpdate()
    {
        _fsm.Driver.FixedUpdate.Invoke();
    }

    # endregion

}
