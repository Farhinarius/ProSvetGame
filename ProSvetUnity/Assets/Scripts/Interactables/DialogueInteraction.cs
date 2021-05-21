using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : MonoBehaviour, IClickable
{
    [SerializeField] private AudioSource _audioSource;

    public float displayTime = 4.0f;

    float timerDisplay;

    private string _name;

    private DialogueManager dialogueManager;

    private GameObject dialogueCanvas;

    void Start()
    {
        
        timerDisplay = -1.0f;
        _name = this.gameObject.name;
        dialogueManager = GetComponent<DialogueManager>();      // can be null
        
        dialogueCanvas = this.transform.GetChild(0).gameObject;
        dialogueCanvas.SetActive(false);
    }
    
    public void OnPointerEnter()
    {
        Debug.Log("Pointer Enter: " + _name);
        timerDisplay = -1.0f;
    }

    public void OnPointerButtonClick()
    {
        Debug.Log("Pointer Click: " + _name);
        dialogueCanvas.SetActive(true);     // if canvas is not active after 4 seconds delay
        dialogueManager.CallDialogue();
    }

    public void OnPointerButtonHold()
    {
        // Debug.Log("Pointer Button Hold: " + _name);
    }

    public void OnPointerExit()
    {
        Debug.Log("Pointer Exit: " + _name);
        if (dialogueManager != null)
            timerDisplay = displayTime;         // run close dialog event
    }

    private void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogueCanvas.SetActive(false);
            }
        }
    }

}
