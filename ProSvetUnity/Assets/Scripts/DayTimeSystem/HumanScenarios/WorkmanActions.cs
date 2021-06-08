using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class WorkmanActions : HumanActions
{
    public Transform workplaceTransform;
    
    public enum States
    {
        CannotWork,
        Work
    }

    StateMachine<States, GeneralDriver> fsm;

    public States CurrentState { get => fsm.State; }


    private void Awake()
    {
        fsm = new StateMachine<States, GeneralDriver>(this);
    }

    protected override void Start()
    {
        base.Start();
        _rb2d = GetComponentInParent<Rigidbody2D>();
        fsm.ChangeState(States.CannotWork);
    }

    void CannotWork_Enter()
    {
        Debug.Log("Cannot Work");
    }

    void CannotWork_FixedUpdate()
    {


            // if (interactiveItems.lamp1.turnedOn)
            //     fsm.ChangeState(States.Work);

    }


    // Update is called once per frame
    private void Update()
    {
        fsm.Driver.Update.Invoke();
    }

    private void FixedUpdate()
    {
        fsm.Driver.FixedUpdate.Invoke();
    }
}
