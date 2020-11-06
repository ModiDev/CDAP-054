﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RSP_MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //Load Scenes..
    }
    public void QuitGame() //Using Quit Button
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
