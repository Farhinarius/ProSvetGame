using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class NavigableCamera : MonoBehaviour
{
    public enum States
    {
        Init,
        CameraFixed,
        CameraTargetMovement,
    }

    # region Fields
    
    StateMachine<States, Driver> fsm;

    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpSpeed = 4;
    [SerializeField] private float _zoomSpeed = 3;
    [SerializeField] private float _zoomInSpeed = 11;
    [SerializeField] private float _movingSpeed = 7;
    [SerializeField] private float _minimumCameraSize = 3;
    [SerializeField] private float _maximumCameraSize = 11;

    private Camera _innerCam;
    private bool roomChanged = false;

    # endregion

    # region StateMachineLogic 

    private void Awake()
    {
        fsm = new StateMachine<States, Driver>(this);
        fsm.ChangeState(States.Init);
    }

    void Init_Enter()
    {
        Debug.Log("Camera Init");
        Application.targetFrameRate = 60;
        _innerCam = GetComponent<Camera>();

        Navigable.onRoomTargetChanged += SetUpViewRoom;

        var cameraInitialPosition = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        transform.position = cameraInitialPosition;
        StartCoroutine(SetInitialTransform());

        fsm.ChangeState(States.CameraFixed);
    }

    void CameraFixed_Enter()
    {
        Debug.Log("Camera Fixed Enter");
    }

    void CameraFixed_Update()
    {
        ListenZoom();
        MoveCameraWithMouse();

        if (roomChanged)
        {
            fsm.ChangeState(States.CameraTargetMovement);
            roomChanged = false;
        }
    }

    void CameraTargetMovement_Enter()
    {
        Debug.Log("Camera TargetMovement Enter");
    }

    void CameraTargetMovement_FixedUpdate()
    {
        if (Vector2.Distance(_target.position, transform.position) < 0.1f
        && _innerCam.orthographicSize == _minimumCameraSize)
            fsm.ChangeState(States.CameraFixed);

        MoveToTarget();
    }

    # endregion

    # region DefaultUpdates

    public void Update()
    {
        fsm.Driver.Update.Invoke();
    }

    private void FixedUpdate()
    {
        fsm.Driver.FixedUpdate.Invoke();
    }

    # endregion

    # region CameraMethods

    public void SetUpViewRoom(Transform target, Navigable nav)
    {
        if (_target != target)          // if we do not pick current view room
        {
            roomChanged = true;
            _target = target;
        }
    }

    IEnumerator SetInitialTransform()
    {
        float size = _innerCam.orthographicSize;
        while (size > _minimumCameraSize)
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);
            size -= 17 * Time.fixedDeltaTime;
            _innerCam.orthographicSize = size;
        }
    }

    private void MoveCameraWithMouse()
    {
        if (Input.GetMouseButton(2))
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * _movingSpeed,
                                                  Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * _movingSpeed);
            }
        }
    }

    private void ListenZoom()
    {
        float size = _innerCam.orthographicSize;

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            size -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
            size = Mathf.Clamp(size, _minimumCameraSize, _maximumCameraSize);
        }

        _innerCam.orthographicSize = size;
    }

    private void MoveToTarget()
    {
        // lerp movement logic
        var positionToMove = Vector2.Lerp(transform.position, _target.position, _lerpSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(positionToMove.x, positionToMove.y, transform.position.z);

        // zoom logic
        float size = _innerCam.orthographicSize;
        size -=  _zoomInSpeed * Time.deltaTime;
        size = Mathf.Clamp(size, _minimumCameraSize, _maximumCameraSize);
        _innerCam.orthographicSize = size;
    }

    # endregion
}
