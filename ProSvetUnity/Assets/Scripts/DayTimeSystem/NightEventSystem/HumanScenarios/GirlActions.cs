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
        MovingToDestination,
        Sleep
    }

    StateMachine<States, HumanDriver> _fsm;

    public States CurrentState => _fsm.State;

    private bool ItemsIsActivated =>
        !LevelInfo.InteractableItems.lamp.turnedOn &&
        LevelInfo.InteractableItems.cat.isTurnedOn;

    private bool ItemsIsDeactivated =>
        LevelInfo.InteractableItems.lamp.turnedOn ||
        !LevelInfo.InteractableItems.cat.isTurnedOn;

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
        SetDestination(LevelInfo.Destinations.bed);
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
            if ( _target == LevelInfo.Destinations.bed)
                _fsm.ChangeState(States.Rest);
            else if ( _target == LevelInfo.Destinations.sofa)
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
        SetDestination(LevelInfo.Destinations.sofa);
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