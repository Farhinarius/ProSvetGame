using System.Globalization;
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
        CannotWork,
        MovingToDestination,
        Work,
        TakeAShower,
        Sleep,
        SleepDissatisfied
    }

    StateMachine<States, HumanDriver> _fsm;

    public States CurrentState => _fsm.State;

    public StateMachine<States, HumanDriver> FSM => _fsm;

    private bool lampIsTurnedOn =>
        LevelInfo.InteractableItems.lamp1._turnedOn;

    private bool lampIsTurnedOff =>
        !LevelInfo.InteractableItems.lamp1._turnedOn;
    
    private bool showerIsWorking =>
        LevelInfo.InteractableItems.shower._turnedOn;

    private void Awake()
    {
        _fsm = new StateMachine<States, HumanDriver>(this);
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
        timer = 1.0f;
    }

    void CannotWork_Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else
        if (lampIsTurnedOn)
        {
            StartCoroutine(WaitMoveTo(LevelInfo.Destinations.workPlace));
            _fsm.ChangeState(States.Work);
        }
    }

    void Work_Enter()
    {
        Debug.Log("Enter 'Work' state");
        // change sprite 
        timer = debugTime;
    }
    void Work_Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        if (timer <= 0 || lampIsTurnedOff)
        {
            if (lampIsTurnedOff)
            {
                StartCoroutine(WaitMoveTo(LevelInfo.Destinations.cannotWorkPosition));
                _fsm.ChangeState(States.CannotWork);
            }

            if (showerIsWorking)
            {
                StartCoroutine(WaitMoveTo(LevelInfo.Destinations.shower));
                _fsm.ChangeState(States.TakeAShower);
            }
            else
                _fsm.ChangeState(States.Work);  // return to this state and repeat work time
        }
    }

    void TakeAShower_Enter()
    {
        Debug.Log("Enter 'TakeAShower' state");
        // change sprite
        timer = debugTime;
    }

    void TakeAShower_Update()
    {
        if (!showerIsWorking)
        {
            StartCoroutine(WaitMoveTo(LevelInfo.Destinations.workmanSleep));
            _fsm.ChangeState(States.SleepDissatisfied);
        }
 
        if (timer > 0) timer -= Time.deltaTime;
        else  
        {
            StartCoroutine(WaitMoveTo(LevelInfo.Destinations.workmanSleep));
            _fsm.ChangeState(States.Sleep);
        }
    }

    void Sleep_Enter()
    {
        Debug.Log("Enter 'Sleep' state");
        // change sprite
    }

    void SleepDissatisfied_Enter()
    {
        Debug.Log("Enter 'SleepDissatisfied' state");
        // change sprite
    }


    # region StateMachine Driver Methods

    private void Update()
    {

        _fsm.Driver.Update.Invoke();
    }

    private void FixedUpdate()
    {
        _fsm.Driver.FixedUpdate.Invoke();
    }

    private void OnMouseButtonClick()
    {
        _fsm.Driver.OnMouseButtonClick.Invoke();
    }

    # endregion

}
