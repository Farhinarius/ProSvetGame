using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Clickable : MonoBehaviour
{
    public string Name;
    public bool IsEnabled { get; set; }
    public Renderer rend;


    public void CallYourName()
    {
        Debug.Log(Name);
    }

    public virtual void Highlight()
    {
        Debug.Log("Pointer is over" + Name);
    }

    public virtual void Deselect()
    {
        Debug.Log("Pointer is exit" + Name);
    }

    public virtual void Set()
    {
        IsEnabled = !IsEnabled;
        Debug.Log(Name + "is enabled: " + IsEnabled);
    }


}
