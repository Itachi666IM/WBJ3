using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Plot1Manager : MonoBehaviour
{
    public void Study()
    {
        SceneManager.LoadScene("Exam");
    }

    public void PlayAGame()
    {
        SceneManager.LoadScene("Pong");
    }
}
