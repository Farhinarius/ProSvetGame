using System.Collections;
using UnityEngine;

public class MovablePrev : MonoBehaviour, IClickable
{
    [SerializeField] string Name;

    private Transform rightPlace;
    private Vector2 initialPosition;

    private Vector2 mousePosition;

    private float deltaX, deltaY;
    private static bool locked;
    private Camera sceneCamera;


    void Start()
    {
        initialPosition = transform.position;
        sceneCamera = Camera.main;
    }

    public void OnPointerClick()
    {
        Debug.Log("Pointer is ok" + Name);
    }

    public void OnPointerEnter()
    {
        Debug.Log("OnPointerEnter" + Name);

        if (!locked)
        {
            deltaX = sceneCamera.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = sceneCamera.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    void OnMouseDrag()
    {
        if (!locked)
        {
            mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    public void OnPointerExit()
    {
        Debug.Log("OnPointerExit" + Name);
    }

}