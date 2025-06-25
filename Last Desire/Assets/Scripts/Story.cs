using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Story : MonoBehaviour
{
    public string[] dialogues;
    public TMP_Text dialogueText;
    int index = 0;
    string currentDialogue;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject cutSceneButton;
    private void Start()
    {
        dialogueText.text = "";
        currentDialogue = dialogues[index];
        StartCoroutine(NextSentence());
    }

    IEnumerator NextSentence()
    {
        foreach(char c in currentDialogue.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueButton.SetActive(true);
    }

    public void NextDialogue()
    {
        if (dialogueText.text == currentDialogue)
        {
            if (index < dialogues.Length - 1)
            {
                index++;
                currentDialogue = dialogues[index];
                dialogueText.text = "";
                StartCoroutine(NextSentence());
            }
            else
            {
                dialogueText.text = "";
                if(cutSceneButton != null)
                {
                    cutSceneButton.SetActive(true);
                }
            }
        }
    }
}
