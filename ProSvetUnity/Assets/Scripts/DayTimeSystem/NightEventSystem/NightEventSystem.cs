using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;
using static ControlProgressBar.Limits;

public class NightEventSystem : ScriptableEventSystem
{
    # region States

    [System.Serializable]
    public enum States
    {
        Init,
        DoStuff,     // RestOrTakeAShower 
        BadDreams,
        OneGoodDream,
        BestDream
    }

    #endregion

    # region Fields 

    StateMachine<States, GeneralDriver> _fsm;
    
    public States CurrentState => _fsm.State;

    [SerializeField] private LevelData _levelData;

    [SerializeField] private GirlActions _girlActions;
    [SerializeField] private WorkmanActions _workmanActions;

    [SerializeField] private float escapeTime;
    [SerializeField] private float escapeTimer;

    [SerializeField] private ControlProgressBar progressBar;

    # endregion

    # region Properties

    public LevelData LevelInfo => _levelData;

    # endregion

    private void Awake()
    {
        _fsm = new StateMachine<States, GeneralDriver>(this);
    }

    # region MonoBehaviour Methods

    private void Start()
    {
        _girlActions.enabled = true;
        _workmanActions.enabled = true;
        _fsm.ChangeState(States.Init);
    }

    private void OnDisable()
    {
        _girlActions.enabled = false;
        _workmanActions.enabled = false;
    }

    public void StateCallback(GirlActions.States girlState)
    {
        DefineState();
    }

    public void StateCallback(WorkmanActions.States workmanState)
    {
        DefineState();
    }

    # endregion

    void Init_Enter()
    {
        Debug.Log("Enter in night state machine event system (Init state)");

        // when any item is being clicked, check event system
        // InteractableItem.onMousePointerClick += DefineState;


        // This code RAISES EXCEPTION!!!    // Fix
        _girlActions.FSM.Changed += StateCallback;
        _workmanActions.FSM.Changed += StateCallback;
    }

    void DoStuff_Enter()
    {
        Debug.Log("Enter 'DoStuff' state");
    }

    void BadDreams_Enter()
    {
        Debug.Log("Enter 'BadDreams' state");
    }
    
    void OneGoodDream_Enter()
    {
        Debug.Log("Enter 'OneGoodDream' state");
    }
        
    void BestDream_Enter()
    {
        Debug.Log("Enter 'Best Dream' state");
    }

    private void DefineState()
    {
        switch (CurrentState)
        {
            case States.Init:
                
                if (_girlActions.CurrentState != GirlActions.States.Sleep &&
                    _girlActions.CurrentState != GirlActions.States.SleepDissatisfied &&
                    _workmanActions.CurrentState != WorkmanActions.States.Sleep &&
                    _workmanActions.CurrentState != WorkmanActions.States.SleepDissatisfied)
                {
                    _fsm.ChangeState(States.DoStuff);       // 1 star gain

                    StartCoroutine(progressBar.DrawValue(OneStar));
                }
                break;
                
            case States.DoStuff:

                if (_girlActions.CurrentState == GirlActions.States.SleepDissatisfied &&
                    _workmanActions.CurrentState == WorkmanActions.States.SleepDissatisfied)
                {
                    _fsm.ChangeState(States.BadDreams);     // transit to 1 star   state lock
                }
                
                if (_girlActions.CurrentState == GirlActions.States.Sleep ||
                    _workmanActions.CurrentState == WorkmanActions.States.Sleep)
                {
                    _fsm.ChangeState(States.OneGoodDream);  // transit to 2 stars
                    
                    StartCoroutine(progressBar.DrawValue(TwoStar));
                }

                break;

            case States.OneGoodDream:
                
                if (_girlActions.CurrentState == GirlActions.States.Sleep &&
                    _workmanActions.CurrentState == WorkmanActions.States.Sleep)
                {
                    _fsm.ChangeState(States.BestDream);       // transit to 3 stars state lock

                    StartCoroutine(progressBar.DrawValue(ThreeStar));
                }
                
                if (_girlActions.CurrentState != GirlActions.States.Sleep &&
                    _workmanActions.CurrentState != WorkmanActions.States.Sleep)
                {
                    _fsm.ChangeState(States.DoStuff);
                }
                
                if (_girlActions.CurrentState == GirlActions.States.SleepDissatisfied &&
                    _workmanActions.CurrentState == WorkmanActions.States.SleepDissatisfied)
                {
                    _fsm.ChangeState(States.BadDreams);     // transit to 1 stars   state lock

                    StartCoroutine(progressBar.DrawValue(OneStar));
                }

                break;
        }

    }

}
