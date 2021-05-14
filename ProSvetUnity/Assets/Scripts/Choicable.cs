using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choicable : MonoBehaviour, IClickable
{
    [SerializeField] private AudioSource _audioSource;
    private string _name;

    void Start()
    {
        _name = this.gameObject.name;
    }

    public void OnPointerClick()
    {
        Debug.Log("Pointer Click: " + _name);
    }

    public void OnPointerEnter()
    {
        Debug.Log("Poitner Enter: " + _name);
    }

    public void OnPointerExit()
    {
        Debug.Log("Pointer Exit: " + _name);
    }

}
