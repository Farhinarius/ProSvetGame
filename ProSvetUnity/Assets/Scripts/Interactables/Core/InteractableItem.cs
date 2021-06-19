using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractableItem : Interactable
{
    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
