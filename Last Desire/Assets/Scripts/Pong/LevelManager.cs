using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Plot 1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting...");
    }
}
