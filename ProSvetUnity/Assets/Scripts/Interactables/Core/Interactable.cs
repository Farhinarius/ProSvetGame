using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IPointerHandler
{
    [SerializeField] protected AudioSource _audioSource;
    protected string _name;

    public static event Action OnMouseEnter;
    public static event Action OnMouseButtonClick;
    public static event Action OnMouseExit;

    protected virtual void Start()
    {
        _name = this.gameObject.name;
    }

    public virtual void OnPointerEnter()
    {
        // Debug.Log("Poitner Enter: " + _name);
        OnMouseEnter?.Invoke();
    }

    public virtual void OnPointerButtonClick()
    {
        // Debug.Log("Pointer Click: " + _name);
        OnMouseButtonClick?.Invoke();

        if (_audioSource != null)
            _audioSource.Play();
    }

    public virtual void OnPointerButtonHold()
    {
        // Debug.Log("Pointer Button Hold: " + _name);
    }

    public virtual void OnPointerExit()
    {
        // Debug.Log("Pointer Exit: " + _name);
        OnMouseExit?.Invoke();
    }
}
