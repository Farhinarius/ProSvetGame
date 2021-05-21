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

    StateMachine<States, Driver> fsm;

    public States CurrentState { get => fsm.State; }

    public const float changeTime = 2.5f;

    int direction = 1;

    float timer;

    Rigidbody2D rb2d;

    public float speed = 4;

    private void Awake()
    {
        fsm = new StateMachine<States, Driver>(this);
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    void Start()
    {
        interactiveItems = nightEventSystem.interactiveItems;
        rb2d = GetComponentInParent<Rigidbody2D>();
        fsm.ChangeState(States.CannotWork);
    }

    void CannotWork_Enter()
    {
        Debug.Log("Cannot work" + transform.parent.name);
    }

    void CannotWork_Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        if (interactiveItems.lamp1.turnedOn)
            fsm.ChangeState(States.Work);
    }

    void CannotWork_FixedUpdate()
    {
        Vector2 objPos = rb2d.position;
        objPos.x += speed * Time.fixedDeltaTime * direction;
        rb2d.MovePosition(objPos);
    }

    void Work_Enter()
    {
        
    }

    void Work_Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, workplaceTransform.position, speed * Time.fixedDeltaTime);
        
        if (interactiveItems.lamp0.turnedOn)
            fsm.ChangeState(States.CannotWork);
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
