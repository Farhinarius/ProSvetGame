using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Selector : MonoBehaviour
{
   
    private Camera sceneCamera;
    private RaycastHit2D onHit;

    private IClickable current, previous;
    private SpriteRenderer concuredTerritory;


    void Start()
    {
        sceneCamera = Camera.main;
    }

    void Update()
    {
        var mousePos = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        onHit = Physics2D.Raycast(mousePos, Vector2.zero);


        if (onHit && onHit.collider.TryGetComponent(out IClickable predmet))
        {
            previous = current;
            current = predmet;

            if (previous != current)
                predmet.OnPointerEnter();


            if (Input.GetMouseButtonDown(0))
            {
                predmet.OnPointerClick();
            }

        }
        else if (current != null)
        {
            current.OnPointerExit();
            current = null;
        }
        
        // в том случае если хит продолжается, но объекты стоят вплотную 
        if (onHit && previous != null && previous != current)
        {
            previous.OnPointerExit();
            previous = null;
        }
    }

}


