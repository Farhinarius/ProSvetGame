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

    StateMachine<States, Driver> fsm;

    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpSpeed;
    [SerializeField] private float _zoomSpeed;
    [SerializeField] private float _zoomInSpeed;
    [SerializeField] private float _movingSpeed;
    private Camera _innerCam;
    private bool roomChanged = false;


    private void Awake()
    {
        fsm = new StateMachine<States, Driver>(this);
        fsm.ChangeState(States.Init);
    }

    // ---------- State Machine Behaviour ----------
    void Init_Enter()
    {
        Debug.Log("Camera Init");
        Application.targetFrameRate = 60;
        _innerCam = GetComponent<Camera>();

        Navigable.onRoomTargetChanged += SetUpViewRoom;
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
        if (Mathf.Abs(transform.position.x - _target.position.x) <= 0.2f
        && Mathf.Abs(transform.position.y - _target.position.y) <= 0.2f
        && _innerCam.orthographicSize == 7)
            fsm.ChangeState(States.CameraFixed);

        MoveToTarget();
    }


    // ---------- Class methods ----------
    public void Update()
    {
        fsm.Driver.Update.Invoke();
    }

    private void FixedUpdate()
    {
        fsm.Driver.FixedUpdate.Invoke();
    }

    public void SetUpViewRoom(Transform target, Navigable nav)
    {
        roomChanged = true;
        _target = target;
    }

    IEnumerator SetInitialTransform()
    {
        float size = _innerCam.orthographicSize;
        while (size > 8 && transform.position != _target.position)
        {
            yield return new WaitForSeconds(0.016f);
            size -= _zoomInSpeed * 0.1f;
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
            size = Mathf.Clamp(size, 1, 15);
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
        size = Mathf.Clamp(size, 7, 15);
        _innerCam.orthographicSize = size;
    }


}
