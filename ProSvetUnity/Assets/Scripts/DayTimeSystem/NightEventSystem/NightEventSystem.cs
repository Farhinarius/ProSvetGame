using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MonsterLove.StateMachine;

public class NightEventSystem : ScriptableEventSystem
{
    # region Structs

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

    [SerializeField] private InteractableItems _items;

    [SerializeField] private Destinations _destinations;

    [SerializeField] private HumanActions _girlActions, _workmanActions;

    public InteractableItems InteractableItems { get => _items; }

    public Destinations Destinations { get => _destinations; }

    List<Transform> list;


    # endregion

    private void Awake()
    {
        list = new List<Transform>();
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
