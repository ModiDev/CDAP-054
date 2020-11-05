using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_EC : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene(2);
    }

    public void exit()
    {
        Application.Quit(0);
    }

    public void Level1()
    {
        SceneManager.LoadScene(3);
    }

    public void Level2()
    {
        SceneManager.LoadScene(4);
    }

    public void Level3()
    {
        SceneManager.LoadScene(5);
    }

    public void Level4()
    {
        SceneManager.LoadScene(6);
    }

    public void backtoevel()
    {
        SceneManager.LoadScene(2);
    }

    public void disposelevel()
    {
        SceneManager.LoadScene(6);
    }
}
