﻿using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour, IPointerHandler
{
    [SerializeField] protected AudioSource _audioSource;
    protected string _name;

    protected virtual void Start()
    {
        _name = this.gameObject.name;
    }

    public virtual void OnPointerEnter()
    {
        // Debug.Log("Poitner Enter: " + _name);
    }

    public virtual void OnPointerButtonClick()
    {
        // Debug.Log("Pointer Click: " + _name);

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
    }

}
