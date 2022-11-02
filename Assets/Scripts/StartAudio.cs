using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    private AudioManager audioManager;
    //cache
    public string sound = "Intro";
    void Start()
    {
        audioManager = AudioManager.instance;
        if(audioManager == null)
        {
            Debug.LogError("no audiomanager found");
            
        }else audioManager.PlaySound(sound);

        
        
    }

    // Update is called once per frame
    
}
