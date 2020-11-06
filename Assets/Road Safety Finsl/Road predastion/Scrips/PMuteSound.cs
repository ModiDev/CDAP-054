using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mute Sound Scenes...
public class PMuteSound : MonoBehaviour
{
    private bool isMuted;

    void Start()
    {
        isMuted = false;
    }

    //Call Method using Mute Button
    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }
}
