using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class NightEventSystem : ScriptableEventSystem
{
    # region States

    [System.Serializable]
    enum States
    {
        Init,
        AllTiredAndSleepy,
        gDoNothingwWorking,
        gRestwCannotWork
    }

    #endregion

    # region Fields 

    StateMachine<States, GeneralDriver> _fsm;

    [SerializeField] private LevelData _levelData;

    [SerializeField] private HumanActions _girlActions, _workmanActions;

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
        _fsm.ChangeState(States.Init);
    }

    void Init_Enter()
    {
        Debug.Log("Enter in night state machine event system (Init state)");

        _girlActions.enabled = true;
        _workmanActions.enabled = true;
        
        _fsm.ChangeState(States.AllTiredAndSleepy);
    }

    void AllTiredAndSleepy_Enter()
    {
        Debug.Log("Enter All Tired and Sleepy");
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

}
