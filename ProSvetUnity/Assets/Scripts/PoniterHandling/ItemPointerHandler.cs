using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPointerHandler : PointerHandler
{
    public RaycastHit2D interactableHit;

    void Update()
    {
        interactableHit = Physics2D.Raycast(MouseTarget, Vector2.zero, 0f, LayerMask.GetMask("Interactable"));
        HandleSinglePointer(interactableHit);
    }
}
