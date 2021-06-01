using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomPointerHandler : PointerHandler
{
    // ? fix
    // ! errors to fix
    // * done if mouse cover interactable object, we not detect navigable object, cast ray only in interactable obj 
    // -> collect array of raycast point and handle we 
    // -> layer selection priority (filter hit by layer in one script ???) if one hit in this layer than do this stuff, else do this stuff

    RaycastHit2D roomHit;

    ItemPointerHandler _itemPointerHandler;

    DialoguePointerHandler _dialoguePointerHandler;

    private void Start()
    {
        _itemPointerHandler = GetComponent<ItemPointerHandler>();
        _dialoguePointerHandler = GetComponent<DialoguePointerHandler>();
    }
        

    void Update()
    {
        if (!_itemPointerHandler.interactableHit && !_dialoguePointerHandler.dialogueHit)
        {
            roomHit = Physics2D.Raycast(MouseTarget, Vector2.zero, 0f, LayerMask.GetMask("Navigable"));
            HandleSinglePointer(roomHit);
        }
        
    }
}
