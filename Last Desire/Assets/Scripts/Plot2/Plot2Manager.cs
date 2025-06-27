using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Plot2Manager : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("VisualNovel");
    }
}
