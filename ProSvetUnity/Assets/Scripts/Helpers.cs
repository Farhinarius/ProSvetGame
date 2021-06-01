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

    public static void ToggleComponentsCollection(List<Interactable> items, bool state)
        => items.ForEach(ic => ic.enabled = state);

    
}
