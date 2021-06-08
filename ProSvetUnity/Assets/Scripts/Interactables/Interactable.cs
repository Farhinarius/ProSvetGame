using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IPointerHandler
{
    [SerializeField] protected AudioSource _audioSource;
    protected string _name;

    public event Action onPointerEnter;
    public event Action onPointerButtonClick;
    public event Action onPointerButtonHold;
    public event Action onPointerExit;

    protected virtual void Start()
    {
        _name = this.gameObject.name;
    }

    public virtual void OnPointerEnter()
    {
        onPointerEnter?.Invoke();
        // Debug.Log("Poitner Enter: " + _name);
    }

    public virtual void OnPointerButtonClick()
    {
        onPointerButtonClick?.Invoke();
        // Debug.Log("Pointer Click: " + _name);
    }

    public virtual void OnPointerButtonHold()
    {
        onPointerButtonHold?.Invoke();
        // Debug.Log("Pointer Button Hold: " + _name);
    }

    public virtual void OnPointerExit()
    {
        onPointerExit?.Invoke();
        // Debug.Log("Pointer Exit: " + _name);
    }
}
