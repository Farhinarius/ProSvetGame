using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour
{
    private int dialogueID = 0;
    public static int numberOfObjects;
    
    [SerializeField] private Dialogue dialogue;
    private Queue<string> dialogueQueue;
    public Text dialogueDisplay;

    private static bool[] dialogueChecks;

    public static bool allChecked = false;

    private void Awake()
    {
        this.dialogueID = numberOfObjects;
        numberOfObjects++;
    }

    void Start()
    {
        if (gameObject.CompareTag("First"))
        {
            dialogueChecks = new bool[numberOfObjects];
            Debug.Log(dialogueChecks.Length);
        }

        dialogueQueue = new Queue<string>();
    }

    public void CallDialogue()
    {
        if (dialogueQueue.Count == 0)       // if dialogue queue is empty restart this dialogue
            StartDialogue(dialogue);        // fill dialogue queue with dialogue strings

        DisplayNextSentence();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start conversation");

        foreach (string sentence in dialogue.sentences)
        {
            dialogueQueue.Enqueue(sentence);
        }
    }


    public void DisplayNextSentence()
    {
        string sentence = dialogueQueue.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        //dialogueText.text = sentence;

        if (dialogueQueue.Count == 0)      // if queue is empty than reset dialog and end dialogue
        {
            CheckDialogueCompletion();

            CheckCompletenessOfAllDialogues();
            EndDialogue();
        }
    }


    IEnumerator TypeSentence (string sentence)
    {
        dialogueDisplay.text = " ";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueDisplay.text += letter;
            yield return null;
        }
    }

    private void CheckDialogueCompletion() => dialogueChecks[dialogueID] = true;

    private void CheckCompletenessOfAllDialogues()
    {
        if (dialogueChecks.All(dc => dc))
        {
            allChecked = true;
            Debug.Log("All checked");

            for (int i = 0; i < dialogueChecks.Length; i++)     // reset in some case
                dialogueChecks[i] = false;
            Debug.Log("Reseted Boolean Array (then changeState)");
        }
    }

    void EndDialogue()
    {
        Debug.Log("end conversation with interactable human");
    }
}
