using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class GirlActions : HumanActions
{
    public Transform restTarget;

    public enum States
    {
        DoNothing,
        Rest
    }

    public float speed = 4;

    StateMachine<States, Driver> fsm;
    
    public States CurrentState { get => fsm.State; }

    public const float changeTime = 2.5f;

    int direction = 1;

    float timer; 

    Rigidbody2D rb2d;

    private void Awake()
    {
        fsm = new StateMachine<States, Driver>(this);
    }

    void Start()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
        fsm.ChangeState(States.DoNothing);
    }

    void DoNothing_Enter()
    {
        Debug.Log("Do Nothing" + transform.parent.name);
    }

    void DoNothing_Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        // if ( interactiveItems.cat.toogler && interactiveItems.lamp0.turnedOn)
        //     fsm.ChangeState(States.Rest);
    }

    void DoNothing_FixedUpdate()
    {
        Vector2 objPos = rb2d.position;
        objPos.x += speed * Time.fixedDeltaTime * direction;
        rb2d.MovePosition(objPos);
    }

    void Sleep_Enter()
    {
        Debug.Log("Sleep Enter" + transform.parent.name);
    }

    void Sleep_Update()
    {
        if (transform.position == restTarget.position)
            return;
        
        transform.position = Vector2.MoveTowards(transform.position, restTarget.position, speed * Time.fixedDeltaTime);
    }

    //------------------------------------------------------------------------//
    private void Update()
    {
        fsm.Driver.Update.Invoke();
    }

    private void FixedUpdate()
    {
        fsm.Driver.FixedUpdate.Invoke();
    }
}