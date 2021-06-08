using UnityEngine;
using MonsterLove.StateMachine;
using System;

public class GirlActions : HumanActions
{
    public enum States
    {
        Null,
        Choice,
        StandStill,
        Rest,
        MovingToDestination,
        Sleep
    }

    StateMachine<States, HumanDriver> _fsm;

    public States CurrentState { get => _fsm.State; }

    private bool ItemsIsActivated =>
        !_nightEventSystem.InteractableItems.lamp.turnedOn &&
        _nightEventSystem.InteractableItems.cat.isSleep;

    private bool ItemsIsDeactivated =>
        _nightEventSystem.InteractableItems.lamp.turnedOn ||
        !_nightEventSystem.InteractableItems.cat.isSleep;

    private void Awake()
    {
        _fsm = new StateMachine<States, HumanDriver>(this);
    }

    protected override void Start()
    {
        base.Start();
        _fsm.ChangeState(States.StandStill);
    }

    void StandStill_Enter() 
    { 
        Debug.Log("Enter StandStill");
    }

    void StandStill_Update()
    {
        if (ItemsIsActivated)
            _fsm.ChangeState(States.MovingToDestination);
    }

    void StandStill_Exit()
    {
        ChangeDestination(_nightEventSystem.Destinations.bed);
    }

    void MovingToDestination_Enter()
    {
        Debug.Log($"Enter MovingToDestination. Move To {_target}");
    }

    void MovingToDestination_Update()
    {
        UpdateMove();

        if (ReachedOf(_target) )
        {
            if ( _target == _nightEventSystem.Destinations.bed)
                _fsm.ChangeState(States.Rest);
            else if ( _target == _nightEventSystem.Destinations.sofa)
                _fsm.ChangeState(States.StandStill);
        }
    }

    void MovingToDestination_Exit()
    {

    }

    void Rest_Enter()
    {
        Debug.Log("Enter Rest");
    }

    void Rest_Update()
    {
        if (ItemsIsDeactivated)
            _fsm.ChangeState(States.MovingToDestination);
    }

    void Rest_Exit()
    {
        ChangeDestination(_nightEventSystem.Destinations.sofa);
    }

    # region StateMachine MonoBehaviour

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