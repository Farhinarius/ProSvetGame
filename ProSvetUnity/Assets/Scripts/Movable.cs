using System.Reflection;
using System.Collections;
using UnityEngine;

public class Movable : MonoBehaviour,  IClickable
{
    private string _name;
    private Vector2 _initialPosition;
    private static bool _locked;
    private float _deltaX, _deltaY;

    void Start ()
    {
        _name = this.gameObject.name;
        _initialPosition = transform.position;
    }

    public void OnPointerEnter()
    {
        Debug.Log("Poitner Enter: " + _name);
        if (!_locked)
        {
            _deltaX = PointerHandler.MouseTarget.x - transform.position.x;
            _deltaY = PointerHandler.MouseTarget.y - transform.position.y;
        }
    }

    public void OnPointerButtonClick()
    {
        Debug.Log("Pointer Click: " + _name);
    }

    public void OnPointerButtonHold()
    {
/*         Debug.Log("Pointer Button Hold: " + _name);
        if (!_locked)
        {
            transform.position = new Vector2(PointerHandler.MouseTarget.x - _deltaX, PointerHandler.MouseTarget.y - _deltaY);
        } */
    }

    public void OnPointerExit()
    {
        Debug.Log("Pointer Exit: " + _name);
    }

    void OnMouseDrag()
    {
        if (!_locked)
            transform.position = PointerHandler.MouseTarget;
    }
}
