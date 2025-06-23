using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public class VNManager : MonoBehaviour
{
    public TMP_Text speakerText;
    public TMP_Text currentDialogueText;
    public TMP_Text choiceText1;
    public TMP_Text choiceText2;
    public TMP_Text choiceText3;
    public GameObject continueButton;
    public GameObject choiceButton;
    public GameObject dialoguePanel;
    public GameObject choicesPanel;
    [Serializable]
    public class Dialogue
    {
        public string speaker;
        public string[] dialogues;
    }

    [Serializable]
    public class Choices
    {
        public string choice1;
        public string choice2;
        public string choice3;
    }

    public Dialogue[] allDialogues;
    public Choices[] allChoices;
    Dialogue currentDialogue;
    int speakerIndex = 0;
    int dialogueIndex = 0;
    int choiceIndex = 0;

    private int goodChoice = 0;
    private void Start()
    {
        currentDialogue = allDialogues[speakerIndex];
        speakerText.text = currentDialogue.speaker;
        currentDialogueText.text = currentDialogue.dialogues[dialogueIndex];

    }

    public void NextDialogue()
    {
        if(dialogueIndex<currentDialogue.dialogues.Length - 1)
        {
            dialogueIndex++;
            currentDialogueText.text = currentDialogue.dialogues[dialogueIndex];
        }
        else
        {
            speakerText.text = "";
            currentDialogueText.text = "";
            continueButton.SetActive(false);
            if(choiceIndex<allChoices.Length)
            {
                choiceButton.SetActive(true);
            }
            else
            {
                NextSpeaker();
            }
        }
    }

    public void MakeChoices()
    {
        choiceButton.SetActive(false);
        choicesPanel.SetActive(true);
        dialoguePanel.SetActive(false);
        Choices currentChoice = allChoices[choiceIndex];
        choiceText1.text = currentChoice.choice1;
        choiceText2.text = currentChoice.choice2;
        choiceText3.text = currentChoice.choice3;
        choiceIndex++;
    }

    public void NextSpeaker()
    {
        choicesPanel.SetActive(false);
        dialoguePanel.SetActive(true);
        continueButton.SetActive(true);
        if(speakerIndex<allDialogues.Length-1)
        {
            speakerIndex++;
            dialogueIndex = 0;
            currentDialogue = allDialogues[speakerIndex];
            speakerText.text = currentDialogue.speaker;
            currentDialogueText.text = currentDialogue.dialogues[dialogueIndex];
        }
        else
        {
            if (goodChoice > 0)
            {
                SceneManager.LoadScene("Pong");
            }
            else
            {
                SceneManager.LoadScene("Exam");
            }
             
        }
    }

    public void ChoiceEvalution(int eval)
    {
        goodChoice += eval;
    }
}
