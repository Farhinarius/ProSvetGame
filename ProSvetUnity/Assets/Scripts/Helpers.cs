using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static void ToggleGameObjectsCollection(List<GameObject> interactablesObj, bool state)
    {
        foreach (var interactable in interactablesObj)
            interactable.SetActive(state);
    }

    public static void ToggleInteractableItemComponents(List<InteractableItem> items, bool state)
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].enabled = state;
        }
    }

    public static void TogglePointerHandler(PointerHandler pointerHandler, bool state) =>
        pointerHandler.enabled = state;

    
}
