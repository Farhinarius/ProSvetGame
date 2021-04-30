using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choicable : MonoBehaviour, IClickable
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] string Name;

    public void OnPointerClick()
    {
        Debug.Log("Pointer is ok" + Name);

    }

    public void OnPointerEnter()
    {
        Debug.Log("DDDDDDDDD" + Name);
    }

    public void OnPointerExit()
    {
        Debug.Log("FFFFFFFFt" + Name);
    }

}
