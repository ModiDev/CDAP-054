﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DRestart : MonoBehaviour
{
   public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
