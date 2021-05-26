using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour
{
    private int _dialogueID = 0;
    public static int s_numberOfObjects;
    
    [SerializeField] private Dialogue _dialogue;
    private Queue<string> _dialogueQueue;
    public Text _dialogueDisplay;

    private static bool[] _dialogueChecks;
    public static bool allChecked = false;

    private void Awake()
    {
        this._dialogueID = s_numberOfObjects;
        s_numberOfObjects++;
    }

    void Start()
    {
        if (gameObject.CompareTag("First"))
        {
            _dialogueChecks = new bool[s_numberOfObjects];
            Debug.Log(_dialogueChecks.Length);
        }

        _dialogueQueue = new Queue<string>();
    }

    public void CallDialogue()
    {
        if (_dialogueQueue.Count == 0)       // if dialogue queue is empty restart this dialogue
            StartDialogue(_dialogue);        // fill dialogue queue with dialogue strings

        DisplayNextSentence();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start conversation");

        foreach (string sentence in dialogue.sentences)
        {
            _dialogueQueue.Enqueue(sentence);
        }
    }


    public void DisplayNextSentence()
    {
        string sentence = _dialogueQueue.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        //dialogueText.text = sentence;

        if (_dialogueQueue.Count == 0)      // if queue is empty than reset dialog and end dialogue
        {
            SetDialogueCompletion();

            CheckCompletenessOfAllDialogues();
            EndDialogue();
        }
    }


    IEnumerator TypeSentence (string sentence)
    {
        _dialogueDisplay.text = " ";
        foreach (char letter in sentence.ToCharArray())
        {
            _dialogueDisplay.text += letter;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }

    private void SetDialogueCompletion() => _dialogueChecks[_dialogueID] = true;

    private void CheckCompletenessOfAllDialogues()
    {
        if (_dialogueChecks.All(dc => dc))
        {
            allChecked = true;

            ResetDialogueChecks();
            Debug.Log("All checked");
        }
    }

    private void ResetDialogueChecks()
    {
        for (int i = 0; i < _dialogueChecks.Length; i++)     // reset in some case
            _dialogueChecks[i] = false;

        Debug.Log("Reseted Boolean Array of dialogueChecks (then changeState)");
    }

    void EndDialogue()
    {
        Debug.Log("end conversation with interactable human");
    }
}
