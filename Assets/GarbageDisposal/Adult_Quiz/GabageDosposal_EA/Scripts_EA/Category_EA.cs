using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Category_EA : MonoBehaviour
{
    public void Quiz1() //link to level 1
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Quiz1_EA");
    }

    public void Quiz2() //link to level 2
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Quiz2_EA");
    }

    public void Quiz3() //link to level 3
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Quiz3_EA");
    }
}
