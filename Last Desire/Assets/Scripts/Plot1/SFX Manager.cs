using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private SFX sfx;

    private void Start()
    {
        sfx = FindObjectOfType<SFX>();
    }

    public void PlayAudio(AudioClip audioClip)
    {
        sfx.PlayAnyAudio(audioClip);
    }
}
