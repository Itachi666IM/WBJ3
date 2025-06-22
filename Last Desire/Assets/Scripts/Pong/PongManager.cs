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

    private void Update()
    {
        player1Score.text = score1.ToString();
        player2Score.text = score2.ToString();

        if(score1 == 5 || score2==5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void UpdateScore1()
    {
        score1++;
    }

    public void UpdateScore2()
    {
        score2++;
    }
}
