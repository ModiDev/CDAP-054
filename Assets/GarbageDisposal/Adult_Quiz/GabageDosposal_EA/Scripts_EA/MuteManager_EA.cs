using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteManager_EA : MonoBehaviour
{
    // mute background music and system sound
    private bool isMuted;
       
        void Start()
    {
        isMuted = false;
    }
    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }
}
