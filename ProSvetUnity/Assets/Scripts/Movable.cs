using System.Reflection;
using System.Collections;
using UnityEngine;

public class Movable : MonoBehaviour,  IClickable
{
    private string _name;

    private Vector2 _initialPosition;

    private static bool _locked = false;


    void Start ()
    {
        _name = this.gameObject.name;
        _initialPosition = transform.position;
    } 

    public void OnPointerClick()
    {
        Debug.Log("Pointer Click: " + _name);
    }

    public void OnPointerEnter()
    {
        Debug.Log("Poitner Enter: " + _name);
    }

    void OnMouseDrag()
    {
        // watch on this
        if (!_locked)
            transform.position = PointerHandler.MouseTarget;
    }

    public void OnPointerExit()
    {
        Debug.Log("Pointer Exit: " + _name);
    }

}
