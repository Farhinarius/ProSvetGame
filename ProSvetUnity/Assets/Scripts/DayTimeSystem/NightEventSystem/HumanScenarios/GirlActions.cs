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
        !LevelInfo.InteractableItems.lamp._turnedOn &&
        LevelInfo.InteractableItems.cat._turnedOn;

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
            if ( _target.Equals(LevelInfo.Destinations.bed))
                _fsm.ChangeState(States.Rest);
            else 
            if ( _target.Equals(LevelInfo.Destinations.sofa))
                _fsm.ChangeState(States.StandStill);
        }
    }

    void Rest_Enter()
    {
        Debug.Log("Enter Rest");
    }

    void Rest_Update()
    {
        if (ItemsIsDeactivated)
            _fsm.ChangeState(States.MovingToDestination);

        if (!sinkIsOpened)
            _fsm.ChangeState(States.Sleep);
    }

    void Rest_Exit()
    {
        SetDestination(LevelInfo.Destinations.sofa);
    }

    void Sleep_Enter()
    {
        Debug.Log("Enter 'Sleep' state");
    }

    void Sleep_Update()
    {
        if (sinkIsOpened)
            _fsm.ChangeState(States.Rest);
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