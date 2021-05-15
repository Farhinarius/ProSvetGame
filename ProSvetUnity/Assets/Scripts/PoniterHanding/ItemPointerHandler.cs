using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPointerHandler : PointerHandler
{
    RaycastHit2D interactHit;
    
    private void Start()
    {
        Debug.Log(LayerMask.GetMask("Interactable"));
    }

    void Update()
    {
        interactHit = Physics2D.Raycast(MouseTarget, Vector2.zero, 0f, LayerMask.GetMask("Interactable"));
        HandleSinglePointer(interactHit);
    }
}
