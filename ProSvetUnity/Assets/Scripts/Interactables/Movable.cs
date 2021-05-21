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
    }

    public void OnPointerButtonClick()
    {
        Debug.Log("Pointer Click: " + _name);
    }

    public void OnPointerButtonHold()
    {
/*         Debug.Log("OnPointerButtonHold");
        transform.position = PointerHandler.MouseTarget; */
    }

    public void OnPointerExit()
    {
        Debug.Log("Pointer Exit: " + _name);
    }

    // void OnMouseDrag()
    // {
    //     Debug.Log("OnMouseDrag");
    //     transform.position = PointerHandler.MouseTarget;
    // }
}
