using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class NightEventSystem : ScriptableEventSystem
{
    [SerializeField] private GameObject girlActions;
    
    [SerializeField] private GameObject workmanActions;

    public InteractiveItems interactiveItems;

    enum States
    {
        Init,
        AllTiredAndSleepy,
        gDoNothingwWorking,
        gRestwCannotWork
    }

    StateMachine<States, Driver> fsm;

    private void Awake()
    {
        fsm = new StateMachine<States, Driver>(this);
    }

    private void Start()
    {
        fsm.ChangeState(States.Init);
    }

    // state machine logic
    void Init_Enter()
    {
        girlActions.SetActive(true);
        workmanActions.SetActive(true);
        
        Debug.Log("Enter in night state machine event system (Init state)");
        // fsm.ChangeState(States.AllTiredAndSleepy);
    }

    void AllTiredAndSleepy_Enter()
    {

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

    // other methods

    private void Update()
    {
        fsm.Driver.Update.Invoke();
    }


}
