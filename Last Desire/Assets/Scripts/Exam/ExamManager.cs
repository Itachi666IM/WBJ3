using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;
public class ExamManager : MonoBehaviour
{
    int score;
    int scoreToBeat;
    public TMP_Text questionText;
    public TMP_Text displayAnswerText;
    public GameObject continueButton;
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;
    public TMP_Text option4;
    [Serializable]
    public class Problems
    {
        public string question;
        public int answer;
        public int[] answersToAssign;
    }

    public List<Problems> problems;
    Problems currentProblem;
    private void Start()
    {
        scoreToBeat = problems.Count/2;
        int randomProblem = Random.Range(0, problems.Count);
        currentProblem = problems[randomProblem];
        problems.Remove(currentProblem);
        questionText.text = currentProblem.question;
        option1.text = currentProblem.answersToAssign[0].ToString();
        option2.text = currentProblem.answersToAssign[1].ToString();
        option3.text = currentProblem.answersToAssign[2].ToString();
        option4.text = currentProblem.answersToAssign[3].ToString();
    }

    void Update()
    {
        if(problems.Count < scoreToBeat)
        {
            if(score>scoreToBeat)
            {
                SceneManager.LoadScene("Plot 2");
            }
            else
            {
                SceneManager.LoadScene("Exam Fail");
            }
        }
    }

    public void ReceivedAnswer(TMP_Text answerText)
    {
        if(answerText.text == currentProblem.answer.ToString())
        {
            score++;
        }
        displayAnswerText.text = "Answer: " + currentProblem.answer.ToString();
        displayAnswerText.gameObject.SetActive(true);
        continueButton.SetActive(true);
    }

    public void NextQuestion()
    {
        continueButton.SetActive(false);
        displayAnswerText.gameObject.SetActive(false);
        int randomProblem = Random.Range(0, problems.Count);
        currentProblem = problems[randomProblem];
        problems.Remove(currentProblem);
        questionText.text = currentProblem.question;
        option1.text = currentProblem.answersToAssign[0].ToString();
        option2.text = currentProblem.answersToAssign[1].ToString();
        option3.text = currentProblem.answersToAssign[2].ToString();
        option4.text = currentProblem.answersToAssign[3].ToString();
    }
}
