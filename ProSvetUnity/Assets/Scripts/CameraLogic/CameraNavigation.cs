﻿using System.Collections;
using UnityEngine;
using MonsterLove.StateMachine;

public class CameraNavigation : MonoBehaviour
{
    #region Fields

    public enum States
    {
        Init,
        CameraFixed,
        CameraTargetMovement,
    }

    StateMachine<States, CameraDriver> fsm;

    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpSpeed; // default 4
    [SerializeField] private float _zoomSpeed; // default 3
    [SerializeField] private float _zoomInSpeed; // default 9
    [SerializeField] private float _movingSpeed; // default 8
    [SerializeField] private float _minimumCameraSize; // default 3
    [SerializeField] private float _maximumCameraSize; // default 11

    private Camera _mainCam;

    public event System.Action handleInput;

    #endregion

    #region StateMachineMethods

    private void Awake()
    {
        fsm = new StateMachine<States, CameraDriver>(this);
        fsm.ChangeState(States.Init);
    }

    void Init_Enter()
    {
        Debug.Log("Camera Init");
        
        // temp set up target framerate
        Application.targetFrameRate = 60;
        
        // get main camera
        _mainCam = GetComponent<Camera>();

        // event subscription
        Navigable.onViewRoomChanged += OnViewRoomChanged;

        handleInput += ListenZoom;
        handleInput += MoveCameraWithMouse;

        // camera setup
        var cameraInitialPosition = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        transform.position = cameraInitialPosition;
        StartCoroutine(SetInitialTransform());

        fsm.ChangeState(States.CameraFixed);
    }

    void CameraFixed_Enter() => Debug.Log("Camera Fixed Enter");

    void CameraFixed_Update() => handleInput?.Invoke();

    void CameraFixed_OnViewRoomChanged() => fsm.ChangeState(States.CameraTargetMovement);

    void CameraTargetMovement_Enter()
    {
        Debug.Log("Camera TargetMovement Enter");
    }

    void CameraTargetMovement_FixedUpdate()
    {
        if (Vector2.Distance(_target.position, transform.position) < 0.1f
        && _mainCam.orthographicSize == _minimumCameraSize)
            fsm.ChangeState(States.CameraFixed);

        MoveToTarget();
    }

    # endregion

    # region StateMachineEvents

    public void Update()
    {
        fsm.Driver.Update.Invoke();
    }

    private void FixedUpdate()
    {
        fsm.Driver.FixedUpdate.Invoke();
    }

    public void OnViewRoomChanged(Transform target)
    {
        if (_target != target) _target = target;
        fsm.Driver.OnViewRoomChanged.Invoke();
    }

    # endregion

    # region CameraMethods

    IEnumerator SetInitialTransform()
    {
        float size = _mainCam.orthographicSize;
        while (size > _minimumCameraSize)
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);
            size -= 17 * Time.fixedDeltaTime;
            _mainCam.orthographicSize = size;
        }
    }

    private void MoveCameraWithMouse()
    {
        if (Input.GetMouseButton(2))
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * 8,
                                                  Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * 8);
            }
        }
    }

    private void ListenZoom()
    {
        float size = _mainCam.orthographicSize;

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            size -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
            size = Mathf.Clamp(size, _minimumCameraSize, _maximumCameraSize);
        }

        _mainCam.orthographicSize = size;
    }

    private void MoveToTarget()
    {
        // lerp movement logic
        var positionToMove = Vector2.Lerp(transform.position, _target.position, _lerpSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(positionToMove.x, positionToMove.y, transform.position.z);

        // zoom logic
        float size = _mainCam.orthographicSize;
        size -=  _zoomInSpeed * Time.deltaTime;
        size = Mathf.Clamp(size, _minimumCameraSize, _maximumCameraSize);
        _mainCam.orthographicSize = size;
    }

    # endregion
}