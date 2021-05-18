using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class DayTimeChangingStateMachine : MonoBehaviour
{
    public enum States 
    {
        Evening,
        Night,
        Morning,
    }

    StateMachine<States, Driver> fsm;

    private bool[] dialogeChecks;

    public static event System.Action<int, DayTimeChangingStateMachine> onBackgroundChange;

    private void Start()
    {
        fsm = new StateMachine<States, Driver>(this);
        fsm.ChangeState(States.Evening);
    }

    void Evening_Enter()
    {
        // enable some scripts for dialog with characters
        onBackgroundChange?.Invoke(0, this);
        // if all dialogs have been read, then go to another state
    }

    void EveningUpdate()
    {

    }
}
