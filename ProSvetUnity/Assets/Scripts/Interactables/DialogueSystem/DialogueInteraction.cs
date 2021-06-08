using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : Interactable
{
    private DialogueManager _dialogueManager;
    private GameObject _dialogueCanvas;

    public float displayTime = 4.0f;
    float timerDisplay;

    protected override void Start()
    {
        base.Start();
        timerDisplay = -1.0f;
        _name = this.gameObject.name;
        _dialogueManager = GetComponent<DialogueManager>();      // can be null

        _dialogueCanvas = this.transform.GetChild(0).gameObject;
        _dialogueCanvas.SetActive(false);

        onPointerButtonClick += ShowDialogue;
        onPointerExit += ResetDialogue;
    }
    
    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
        timerDisplay = -1.0f;
    }

    public override void OnPointerButtonClick()
    {
        base.OnPointerButtonClick();
    }

    public override void OnPointerButtonHold()
    {
        base.OnPointerButtonHold();
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
    }

    private void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                _dialogueCanvas.SetActive(false);
            }
        }
    }

    private void ShowDialogue()
    {
        if (!_dialogueCanvas.activeSelf)
            _dialogueCanvas.SetActive(true);
        _dialogueManager.CallDialogue();
    }

    private void ResetDialogue()
    {
        if (_dialogueManager != null)
            timerDisplay = displayTime;         // run close dialog event
    }

}
