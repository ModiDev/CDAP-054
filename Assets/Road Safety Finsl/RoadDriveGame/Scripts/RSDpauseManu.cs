using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSDpauseManu : MonoBehaviour
{
    public GameObject Pausemenu, PauseButton; 

    public void Pause() //Create Pause Menu 
    {
        Pausemenu.SetActive(true); 
        PauseButton.SetActive(false); //Using Pause Button
        Time.timeScale = 0;
    }

    public void Resume() 
    {
        Pausemenu.SetActive(false);
        PauseButton.SetActive(true); //Using Resume Button
        Time.timeScale = 1;
    }
}
