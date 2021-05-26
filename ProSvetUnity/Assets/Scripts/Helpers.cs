using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static void ToogleAllInteractableOfType(List<GameObject> interactablesObj, bool state)
    {
        foreach (var interactable in interactablesObj)
            interactable.SetActive(state);
    }
}
