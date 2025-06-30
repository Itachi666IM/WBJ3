using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject blockedExit;
    public GameObject openExit;

    [HideInInspector] public int dynamiteCount;
    public TMP_Text dynamiteCountText;
    public AudioClip winSound;
    SFX sfx;

    bool once;
    private void Start()
    {
        sfx = FindObjectOfType<SFX>();
    }

    // Update is called once per frame
    void Update()
    {
        dynamiteCountText.text = dynamiteCount.ToString();
        if(dynamiteCount==5)
        {
            if(!once)
            {
                once = true;
                sfx.PlayAnyAudio(winSound);
            }
            blockedExit.SetActive(false);
            openExit.SetActive(true);
        }
    }

    public void IncreaseDynamiteCount()
    {
        dynamiteCount++;
    }
}
