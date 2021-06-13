using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static void ToggleGameObjectsCollection(List<GameObject> interactables, bool state)
        => interactables.ForEach(io => io.SetActive(state));

    public static void ToggleInteractableItemComponents(List<InteractableItem> items, bool state)
        => items.ForEach(i => i.enabled = state);

    public static void TogglePointerHandler(PointerHandler pointerHandler, bool state) =>
        pointerHandler.enabled = state;

    public static bool Reached(Transform current, Transform target) =>
        Vector2.Distance(current.position, target.position) < 0.1;
}
