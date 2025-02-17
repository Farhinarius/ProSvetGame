﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;
using static Helpers;

public class GirlActions : HumanActions
{
    public enum States
    {
        Null,
        StandStill,
        Rest,
        Sleep,
        SleepDissatisfied
    }

    StateMachine<States, HumanDriver> _fsm;

    public States CurrentState => _fsm.State;

    public StateMachine<States, HumanDriver> FSM => _fsm;

    private bool ItemsIsActivated =>
        !LevelInfo.InteractableItems.lamp._turnedOn &&  // lamp turned off
        LevelInfo.InteractableItems.cat._turnedOn;      // is sleeping

    private bool ItemsIsDeactivated =>
        LevelInfo.InteractableItems.lamp._turnedOn ||
        !LevelInfo.InteractableItems.cat._turnedOn;

    private bool sinkIsOpened =>
        LevelInfo.InteractableItems.sink._turnedOn;

    private void Awake()
    {
        _fsm = new StateMachine<States, HumanDriver>(this);
    }

    protected override void Start()
    {
        base.Start();
        InteractableItem.OnMouseButtonCallback += OnItemClick;
        _fsm.ChangeState(States.StandStill);
    }

    void StandStill_Enter() 
    { 
        Debug.Log("Enter StandStill");
    }

    void StandStill_Update()
    {
        if (ItemsIsActivated)
        {
            StartCoroutine(WaitMoveTo(LevelInfo.Destinations.bed));
            _fsm.ChangeState(States.Rest);
        }
    }

    void Rest_Enter()
    {
        Debug.Log("Enter Rest");
        timer = 4.0f;
    }

    void Rest_Update()
    {
        if (ItemsIsDeactivated)
        {
            StartCoroutine(WaitMoveTo(LevelInfo.Destinations.sofa));
            _fsm.ChangeState(States.StandStill);
        }

        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            if (!sinkIsOpened)
                _fsm.ChangeState(States.Sleep);
            else
                _fsm.ChangeState(States.SleepDissatisfied);
        }
    }

    void Sleep_Enter()
    {
        Debug.Log("Enter 'Sleep' state");
    }

    void Sleep_Update()
    {
        if (ItemsIsDeactivated)
        {
            StartCoroutine(WaitMoveTo(LevelInfo.Destinations.sofa));
            _fsm.ChangeState(States.StandStill);
        }

        if (sinkIsOpened)
            _fsm.ChangeState(States.SleepDissatisfied);
    }

    void SleepDissatisfied_Enter()
    {
        Debug.Log("Enter 'SleepDissatisfied' state");
    }

    #region StateMachine Driver Methods

    private void Update()
    {
        _fsm.Driver.Update.Invoke();
    }

    private void FixedUpdate()
    {
        _fsm.Driver.FixedUpdate.Invoke();
    }

    private void OnItemClick()
    {
        _fsm.Driver.OnMouseButtonClick.Invoke();
    }

    # endregion

}