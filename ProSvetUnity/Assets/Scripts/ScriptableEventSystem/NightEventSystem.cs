using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MonsterLove.StateMachine;

public class NightEventSystem : ScriptableEventSystem
{
    [SerializeField] private GameObject girlActions;
    
    [SerializeField] private GameObject workmanActions;

    enum States
    {
        Init,
        AllTiredAndSleepy,
        gDoNothingwWorking,
        gRestwCannotWork
    }

    StateMachine<States, Driver> fsm;

    [SerializeField] List<Interactable> items;

    private void Awake()
    {
        items = new List<Interactable>();
        fsm = new StateMachine<States, Driver>(this);
    }

    private void OnEnable() => Helpers.ToggleComponentsCollection(items, true);

    
    private void Start()
    {
        fsm.ChangeState(States.Init);
    }

    // state machine logic
    void Init_Enter()
    {
        // or in this place
        // girlActions.SetActive(true);
        // workmanActions.SetActive(true);
        // later replace in iterator activation
        
        Debug.Log("Enter in night state machine event system (Init state)");

        FindAllInteractableComponents();

        Helpers.ToggleComponentsCollection(items, true);
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

    private void OnDisable() => Helpers.ToggleComponentsCollection(items, false);

    // separate methods
    private void FindAllInteractableComponents()
    {
        items.Clear();
        var interactables = Resources.FindObjectsOfTypeAll<Interactable>();
        
        if (interactables != null)
            foreach (var item in interactables) 
                    items.Add(item);
    }
}
