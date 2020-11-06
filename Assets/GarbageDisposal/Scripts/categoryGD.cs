using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class categoryGD : MonoBehaviour
{
    //Home page - garbage disposal 

    public void gameQuiz() //link to the 2d adults home page 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomePage_EA");
    }

    public void gameAction() //link to the 3d children home page
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomePage_EC");
    }
}
