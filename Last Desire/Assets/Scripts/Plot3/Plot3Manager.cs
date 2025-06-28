using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plot3Manager : MonoBehaviour
{
    public void StayHome()
    {
        SceneManager.LoadScene("Stay Home");
    }
    public void GoAsPlanned()
    {
        SceneManager.LoadScene("Level 1");
    }
}
