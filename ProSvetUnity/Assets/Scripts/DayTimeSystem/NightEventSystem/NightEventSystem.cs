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

    StateMachine<States, Driver> _fsm;

    [SerializeField] private InteractableItems _items;

    [SerializeField] private Destinations _destinations = new Destinations();
    
    [SerializeField] private GameObject _girlActionObject, _workmanActionObject;

    HumanActions _girlActions, _workmanActions;


    # endregion

    private void Awake()
    {
        _fsm = new StateMachine<States, Driver>(this);
    }

    private void Start()
    {
        _fsm.ChangeState(States.Init);
    }

    void Init_Enter()
    {
        Debug.Log("Enter in night state machine event system (Init state)");

        _girlActionObject.SetActive(true);
        _workmanActionObject.SetActive(true);

        _girlActions = gameObject.GetComponent<HumanActions>();
        _workmanActions = gameObject.GetComponent<HumanActions>();

        _fsm.ChangeState(States.AllTiredAndSleepy);
    }

    void AllTiredAndSleepy_Enter()
    {
        Debug.Log("Enter All Tired and Sleepy");
    }

    void AllTiredAndSleepy_Update()
    {

    }

    void gRestingwWorking_Enter()
    {

    }

    void gRestingwWorking_Update()
    {

    }

    private void OnDisable()
    {
        _girlActionObject.SetActive(false);
        _workmanActionObject.SetActive(false);
    }

}
