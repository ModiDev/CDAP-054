using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create Pause Manu
public class RSP_pauseManu : MonoBehaviour
{
    public GameObject Pausemenu, PauseButton; 

    public void Pause()
    {
        Pausemenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void Resume() //Using Resume Button
    {
        Pausemenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }
}
