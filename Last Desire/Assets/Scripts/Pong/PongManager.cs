using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PongManager : MonoBehaviour
{
    public TMP_Text player1Score;
    public TMP_Text player2Score;
    int score1 = 0;
    int score2 = 0;
    Racquet racquet1;
    Racquet2 racquet2;
    public ParticleSystem youWin;
    public ParticleSystem nickWin;

    private void Start()
    {
        racquet1 = FindObjectOfType<Racquet>();
        racquet2 = FindObjectOfType<Racquet2>();
    }

    private void Update()
    {
        player1Score.text = score1.ToString();
        player2Score.text = score2.ToString();

        if(score1 == 3)
        {
            SceneManager.LoadScene("P1W");
        }
        else if(score2==3)
        {
            SceneManager.LoadScene("P1L");
        }
    }

    public void UpdateScore1()
    {
        score2++;
        racquet1.ResetVelocity();
        racquet1.gameObject.transform.position = racquet1.defaultPos;
        racquet2.ResetVelocity();
        racquet2.gameObject.transform.position = racquet2.defaultPos;
        nickWin.Play();
    }

    public void UpdateScore2()
    {
        score1++;
        racquet1.ResetVelocity();
        racquet1.gameObject.transform.position = racquet1.defaultPos;
        racquet2.ResetVelocity();
        racquet2.gameObject.transform.position = racquet2.defaultPos;
        youWin.Play();
    }
}
