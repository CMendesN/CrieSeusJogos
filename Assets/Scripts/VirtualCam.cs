using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class VirtualCam : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public GameObject player;
    void Start()
    {
        
    }

    
    void Update()
    {
        // if the player die, stop follow.  
        if (!player)
        {
            vCam.enabled = false;
        }
    }
}
