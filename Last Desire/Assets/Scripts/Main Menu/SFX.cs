using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SFX : MonoBehaviour
{
    private AudioSource myaudio;
    [SerializeField] Slider slider;
    void ManageSingleton()
    {
        int instance = FindObjectsOfType<SFX>().Length;
        if(instance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        myaudio = GetComponent<AudioSource>();
        ManageSingleton();
    }

    public void UpdateVolume()
    {
        myaudio.volume = slider.value;
    }

    public void PlayAnyAudio(AudioClip audio)
    {
        myaudio.PlayOneShot(audio);
    }
}

