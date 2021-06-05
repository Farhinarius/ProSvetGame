using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MonsterLove.StateMachine;

public class NightEventSystem : ScriptableEventSystem
{
    [System.Serializable]
    public struct InteractableItems
    {
        public Clickable cat;

        public Lamp lamp;

        public Lamp lamp1;
    }

    [System.Serializable]
    enum States
    {
        Init,
        AllTiredAndSleepy,
        gDoNothingwWorking,
        gRestwCannotWork
    }

    StateMachine<States, Driver> fsm;

    [SerializeField] private InteractableItems items;

    [SerializeField] private GameObject girlActions, workmanActions;

    private void Awake()
    {
        fsm = new StateMachine<States, Driver>(this);
    }

    private void Start()
    {
        fsm.ChangeState(States.Init);
    }

    void Init_Enter()
    {
        Debug.Log("Enter in night state machine event system (Init state)");
        
        girlActions.SetActive(true);
        workmanActions.SetActive(true);
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

}
