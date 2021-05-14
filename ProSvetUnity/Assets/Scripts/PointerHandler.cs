using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointerHandler : MonoBehaviour
{
    // state machine for choosed object by mouse
    // zoom out camera when moving to certain room
    // stop color breaking when dragging item in room

    private RaycastHit2D _onRayHit;
    private IClickable _currentClickable, _previousClickable;
    private SpriteRenderer _concuredTerritory;

    public static Vector2 MouseTarget
    {
        get 
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void Update()
    {
        // case of two targets ()
        // 
        // if we find interactable object upper navigable object, work with them (ignore navigable)
        RaycastHit2D[] mouseRayHits = Physics2D.RaycastAll(MouseTarget, Vector2.zero);              // can be empty

        // in future may replace on foreach cycle
        if (mouseRayHits.Length > 1 && mouseRayHits.Any(coll => coll.collider.CompareTag("Navigable")))
        {
            // if lies within navigable take first interactable obj
            //_onRayHit = mouseRayHits.Where(ray => ray.collider.CompareTag("Interactable")).First();
            foreach (var rayHit in mouseRayHits)
            {
                if (rayHit.collider.CompareTag("Interactable"))
                {
                    _onRayHit = rayHit;
                    break;
                }
            }
        }
        else if (mouseRayHits.Length == 1)
        {
            _onRayHit = mouseRayHits[0];
        }

        // at one time we can handle only one rayhit
        if (_onRayHit && _onRayHit.collider.TryGetComponent(out IClickable item))       // if hover any IClickable
        {
            _previousClickable = _currentClickable;                                     // keep previous item
            _currentClickable = item;                                                   // set new current item

            if (_previousClickable != _currentClickable)                                
                item.OnPointerEnter();                                                  


            if (Input.GetMouseButtonDown(0))
            {
                item.OnPointerClick();
            }
        }
        else if (_currentClickable != null)                                             // if stop hover any IClickable
        {
            _currentClickable.OnPointerExit();
            _currentClickable = null;
        }

        // в том случае если хит продолжается, но объекты стоят вплотную 
        if (_onRayHit && _previousClickable != null && _previousClickable != _currentClickable)
        {
            _previousClickable.OnPointerExit();
            _previousClickable = null;
        }
    }
}
