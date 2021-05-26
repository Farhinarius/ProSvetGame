using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;
using System.Linq;

public class TimeOfDay : MonoBehaviour
{
    public enum States
    {
        Evening,
        Night,
        Morning
    }

    StateMachine<States, Driver> _fsm;

    public static event System.Action<States, TimeOfDay> onTimeOfDayChange;

    List<GameObject> _dialogueHandlers;

    float stateChangeTimer = 0;

    const float timeToChangeState = 3f;

    GameObject _nightEventSystem;


    private void Awake()
    {
        _fsm = new StateMachine<States, Driver>(this);
    }

    private void Start()
    {
        _dialogueHandlers = new List<GameObject>();
        _nightEventSystem = transform.Find("NightEventSystem").gameObject;
        _nightEventSystem.SetActive(false);

        // fill collection of interactable on scene
        var dialogueInteractions = Resources.FindObjectsOfTypeAll<DialogueInteraction>();
        foreach (var diComponent in dialogueInteractions)
        {
            Debug.Log(diComponent.transform.parent.name);
            _dialogueHandlers.Add(diComponent.gameObject);
        }

        _fsm.ChangeState(States.Evening);
    }

    void Evening_Enter()
    {
        onTimeOfDayChange?.Invoke(States.Evening, this);
        Helpers.ToogleAllInteractableOfType(_dialogueHandlers, true);
    }

    void Evening_Update()
    {
        // if all dialogs have been read, then go to another state (later)
        if ( DialogueManager.allChecked)
        {
            stateChangeTimer = timeToChangeState;
            DialogueManager.allChecked = false;
        }

        if (stateChangeTimer > 0) stateChangeTimer -= Time.deltaTime;

        if (stateChangeTimer < 0)
        {
            _fsm.ChangeState(States.Night);
            Debug.Log("ChangeStateToNight");
            stateChangeTimer = 0;       // reset fuild
        }
        
        if (Input.GetKeyDown(KeyCode.X))        // mock while
        {
            _fsm.ChangeState(States.Night);
        }
        
    }

    void Night_Enter()
    {
        onTimeOfDayChange?.Invoke(States.Night, this);
        Helpers.ToogleAllInteractableOfType(_dialogueHandlers, false);
        _nightEventSystem.SetActive(true);
    }

    void Night_Update()
    {
        // if all scriptable events has been passed then go to next phase
        if (Input.GetKeyDown(KeyCode.C))
        {
            _fsm.ChangeState(States.Morning);
        }
    }

    void Morning_Enter()
    {
        onTimeOfDayChange?.Invoke(States.Morning, this);
        _nightEventSystem.SetActive(false);
    }

    void Morning_Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _fsm.ChangeState(States.Evening);
        }
    }



    // ---------- Class methods ----------
    private void Update()
    {
        _fsm.Driver.Update.Invoke();
    }

    // private void FixedUpdate()
    // {
    //     _fsm.Driver.FixedUpdate.Invoke();
    // }

}
