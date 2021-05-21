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
        ToogleAllInteractableOfType(dialogueHandlers, true);

        onTimeOfDayChange?.Invoke(States.Evening, this);
    }

    void Evening_Update()
    {
        // if all dialogs have been read, then go to another state (later)
        if ( DialogueManager.allChecked == true )
        {
            fsm.ChangeState(States.Night);
            Debug.Log("ChangeStateToNight");
        }
        
        if (Input.GetKeyDown(KeyCode.X))        // mock while
        {
            fsm.ChangeState(States.Night);
        }
        
    }

    void Night_Enter()
    {
        ToogleAllInteractableOfType(dialogueHandlers, false);
        onTimeOfDayChange?.Invoke(States.Night, this);
    }

    void Night_Update()
    {
        // if all interacables has been used then change state
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
