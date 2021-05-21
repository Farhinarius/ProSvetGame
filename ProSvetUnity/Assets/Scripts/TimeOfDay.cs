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

    StateMachine<States, Driver> fsm;

    private bool[] dialogeChecks;

    public static event System.Action<States, TimeOfDay> onTimeOfDayChange;

    List<GameObject> dialogueHandlers;

    float stateChangeTimer = 0;

    const float timeToChangeState = 3f;


    private void Awake()
    {
        fsm = new StateMachine<States, Driver>(this);
    }

    private void Start()
    {
        dialogueHandlers = new List<GameObject>();

        foreach (var diComponent in Resources.FindObjectsOfTypeAll<DialogueInteraction>())
        {
            Debug.Log(diComponent.transform.parent.name);
            dialogueHandlers.Add(diComponent.gameObject);
        }
        
        // fill collection of interactable on scene

        fsm.ChangeState(States.Evening);
    }

    void Evening_Enter()
    {
        onTimeOfDayChange?.Invoke(States.Evening, this);
        ToogleAllInteractableOfType(dialogueHandlers, true);
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
            fsm.ChangeState(States.Night);
            Debug.Log("ChangeStateToNight");
            stateChangeTimer = 0;       // reset fuild
        }
        
        if (Input.GetKeyDown(KeyCode.X))        // mock while
        {
            fsm.ChangeState(States.Night);
        }
        
    }

    void Night_Enter()
    {
        onTimeOfDayChange?.Invoke(States.Night, this);
        ToogleAllInteractableOfType(dialogueHandlers, false);
    }

    void Night_Update()
    {
        // if all scriptable events has been passed then go to next phase
        if (Input.GetKeyDown(KeyCode.C))
        {
            fsm.ChangeState(States.Morning);
        }
    }

    void Morning_Enter()
    {
        onTimeOfDayChange?.Invoke(States.Morning, this);
    }

    void Morning_Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            fsm.ChangeState(States.Evening);
        }
    }



    // ---------- Class methods ----------
    private void Update()
    {
        fsm.Driver.Update.Invoke();
    }

    public void ToogleAllInteractableOfType(List<GameObject> interactablesObj, bool state)
    {
        foreach (var interactable in interactablesObj)
            interactable.SetActive(state);                // not necessary code
    }

/*     private void FixedUpdate()
    {
        fsm.Driver.FixedUpdate.Invoke();
    } */

}
