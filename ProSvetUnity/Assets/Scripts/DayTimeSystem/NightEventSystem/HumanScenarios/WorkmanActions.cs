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

    // void CannotWork_Update()
    // {
    //     if (timer > 0) timer -= Time.deltaTime;
    //     else
    //         if (lampIsTurnedOn)
    //             _fsm.ChangeState(States.MovingToDestination);
    // }

    // void CannotWork_Exit()
    // {
    //     SetDestination(LevelInfo.Destinations.workPlace);
    // }

    // void MovingToDestination_Enter()
    // {
    //     Debug.Log($"Enter MovingToDestination. Move To {_target}");
    // }

    // void MovingToDestination_FixedUpdate()
    // {
    //     UpdateMove();

    //     if (Reached(_transform, _target))
    //     {
    //         if (_target.Equals(LevelInfo.Destinations.workPlace))
    //             _fsm.ChangeState(States.Work);
    //         else 
    //         if (_target.Equals(LevelInfo.Destinations.cannotWorkPosition))
    //             _fsm.ChangeState(States.CannotWork);
    //         else
    //         if (_target.Equals(LevelInfo.Destinations.shower))
    //             _fsm.ChangeState(States.TakeAShower);
    //         else 
    //         if (_target.Equals(LevelInfo.Destinations.workmanSleep))
    //             _fsm.ChangeState(States.Sleep);
    //     }
    // }

    // void Work_Enter()
    // {
    //     Debug.Log("Enter 'Work' state");
    //     // change sprite 
    //     timer = debugTime;
    // }

    // void Work_Update()
    // {
    //     if (timer > 0) timer -= Time.deltaTime;
    //     if (timer <= 0 || lampIsTurnedOff)
    //             _fsm.ChangeState(States.MovingToDestination);
    // }

    // void Work_Exit()
    // {
    //     if (lampIsTurnedOff)
    //     {
    //         SetDestination(LevelInfo.Destinations.cannotWorkPosition);
    //         return;
    //     }

    //     if (showerIsWorking)
    //         SetDestination(LevelInfo.Destinations.shower);
    //     else 
    //         _fsm.ChangeState(States.Work);  // return to this state and repeat work time
    // }

    // void TakeAShower_Enter()
    // {
    //     Debug.Log("Enter 'TakeAShower' state");
    //     // change sprite
    //     timer = debugTime;
    // }

    // void TakeAShower_Update()
    // {
    //     if (!showerIsWorking) _fsm.ChangeState(States.MovingToDestination); 
        
    //     if (timer > 0) timer -= Time.deltaTime;
    //     else  
    //         _fsm.ChangeState(States.MovingToDestination);
    // }

    // void TakeAShower_Exit()
    // {
    //     if (!showerIsWorking)
    //         isDissatisfied = true;
    //         // can add agro emotion
        
    //     SetDestination(LevelInfo.Destinations.workmanSleep);
    // }

    // void Sleep_Enter()
    // {
    //     Debug.Log("Enter 'Sleep' state");

    //     if (isDissatisfied)
    //         _fsm.ChangeState(States.SleepDissatisfied);
    //     // change sprite
    // }

    // void SleepDissatisfied_Enter()
    // {
    //     Debug.Log("Enter 'SleepDissatisfied' state");
    //     // change sprite
    // }


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
