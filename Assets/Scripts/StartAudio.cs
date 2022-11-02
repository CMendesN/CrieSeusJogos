using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    public AudioManager audioManager;
    //cache
    public string sound;
    void Start()
    {
        audioManager = AudioManager.instance;
        if(audioManager == null)
        {
            Debug.LogError("no audiomanager found");
            
        }
        audioManager.PlaySound("Environment");



    }

    // Update is called once per frame
    
}
