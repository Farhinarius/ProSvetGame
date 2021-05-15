using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointerHandler : MonoBehaviour
{
    public enum States
    {
        CoversZero,
        CovesrOne,
        CoversMupltiple,
    }
    
    private IClickable _currentClickable, _previousClickable;
    private SpriteRenderer _concuredTerritory;

    public static Vector2 MouseTarget
    {
        get 
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }



/*     void Update()
    {
        // case of two targets ()
        
        // if we find interactable object upper navigable object, work with them (ignore navigable)
        RaycastHit2D[] mouseRayHits = Physics2D.RaycastAll(MouseTarget, Vector2.zero);                   // can be empty


    } */
    
    protected void HandleSinglePointer(RaycastHit2D rayHitObj)
    {
        // at one time we can handle only one rayhit
        if (rayHitObj && rayHitObj.collider.TryGetComponent(out IClickable item))       // if hover any IClickable
        {
            _previousClickable = _currentClickable;                                     // keep previous item
            _currentClickable = item;                                                   // set new current item

            if (_previousClickable != _currentClickable)
                item.OnPointerEnter();


            if (Input.GetMouseButtonDown(0))
            {
                item.OnPointerButtonClick();
            }

            if (Input.GetMouseButton(0))
            {
                item.OnPointerButtonHold();
            } 
        }
        else if (_currentClickable != null)                                             // if stop hover any IClickable
        {
            _currentClickable.OnPointerExit();
            _currentClickable = null;
        }

        // в том случае если хит продолжается, но объекты стоят вплотную 
        if (rayHitObj && _previousClickable != null && _previousClickable != _currentClickable)
        {
            _previousClickable.OnPointerExit();
            _previousClickable = null;
        }
    }
}
