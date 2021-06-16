using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePointerHandler : PointerHandler
{
    public RaycastHit2D dialogueHit;

    void Update()
    {
        dialogueHit = Physics2D.Raycast(MouseTarget, Vector2.zero, 0f, LayerMask.GetMask("Dialogue"));
        HandleSinglePointer(dialogueHit);
    }
}
