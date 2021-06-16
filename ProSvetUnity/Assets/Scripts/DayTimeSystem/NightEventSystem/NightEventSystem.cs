using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class NightEventSystem : ScriptableEventSystem
{
    # region States

    public enum States
    {
        Init,
        AllTiredAndSleepy,
        gDoNothingwWorking,
        gRestwCannotWork
    }

    #endregion

    # region Fields 

    StateMachine<States, GeneralDriver> _fsm;
    
    public States CurrentState => _fsm.State;

    [SerializeField] private LevelData _levelData;

    [SerializeField] private GirlActions _girlActions;
    [SerializeField] private WorkmanActions _workmanActions;

    [SerializeField] private float escapeTime;
    [SerializeField] private float escapeTimer;

    # endregion

    # region Properties

    public LevelData LevelInfo => _levelData;

    # endregion

    private void Awake()
    {
        _fsm = new StateMachine<States, GeneralDriver>(this);
    }

    private void Start()
    {
        _girlActions.enabled = true;
        _workmanActions.enabled = true;
        _fsm.ChangeState(States.Init);
    }

    void Init_Enter()
    {
        Debug.Log("Enter in night state machine event system (Init state)");



    }

    void AllTiredAndSleepy_Enter()
    {
        Debug.Log("Enter 'All Tired and Sleepy' state");
        
    }

    void gRestingwWorking_Enter()
    {

    }

    void gRestingwWorking_Update()
    {

    }

    private void OnDisable()
    {
        _girlActions.enabled = false;
        _workmanActions.enabled = false;
    }

    private void DefineState()
    {
        switch (CurrentState)
        {
            case States.Init:
                if (_girlActions.CurrentState.Equals(GirlActions.States.StandStill)
                    && _workmanActions.CurrentState.Equals(WorkmanActions.States.CannotWork))
                {
                    _fsm.ChangeState(States.AllTiredAndSleepy);
                }
                break;

            case States.AllTiredAndSleepy:
                break;

        }

    }

}
