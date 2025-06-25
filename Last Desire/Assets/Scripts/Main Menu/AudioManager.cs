using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip pongMusic;
    public AudioClip examMusic;
    public AudioClip vnMusic;
    public AudioClip platformerMusic;

    private AudioSource myAudio;

    private void Awake()
    {
        ManageSingleton();
        myAudio = GetComponent<AudioSource>();
    }

    void ManageSingleton()
    {
        int instance = FindObjectsOfType<AudioManager>().Length;
        if(instance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Pong")
        {
            myAudio.clip = pongMusic;
        }
        else if(SceneManager.GetActiveScene().name == "Exam")
        {
            myAudio.clip = examMusic;
        }
        else if(SceneManager.GetActiveScene().name == "VisualNovel")
        {
            myAudio.clip = vnMusic;
        }
        else if(SceneManager.GetActiveScene().name == "Level 1")
        {
            myAudio.clip = platformerMusic;
        }
        else
        {
            myAudio.clip = menuMusic;
        }
        if(!myAudio.isPlaying)
        {
            myAudio.Play();
        }
    }
}
