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

    public void OnPointerButtonClick()
    {
        Debug.Log("Pointer Click: " + _name);
    }
    
    public void OnPointerButtonHold()
    {
        Debug.Log("Pointer Button Hold: " + _name);
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
