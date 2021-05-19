using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

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


    private void Awake()
    {
        fsm = new StateMachine<States, Driver>(this);
    }

    private void Start()
    {
        fsm.ChangeState(States.Evening);
    }

    void Evening_Enter()
    {
        onTimeOfDayChange?.Invoke(States.Evening, this);
        
        // enable behaviours for dialog with characters

    }

    void Evening_Update()
    {
        // if all dialogs have been read, then go to another state (later)
        if (Input.GetKeyDown(KeyCode.X))        // mock while
        {
            fsm.ChangeState(States.Night);
        }
        
    }

    void Night_Enter()
    {
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
    public void Update()
    {
        fsm.Driver.Update.Invoke();
    }

/*     private void FixedUpdate()
    {
        fsm.Driver.FixedUpdate.Invoke();
    } */

}
