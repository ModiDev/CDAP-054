using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Category_EA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Quiz1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Quiz1_EA");
    }

    public void Quiz2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Quiz2_EA");
    }

    public void Quiz3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Quiz3_EA");
    }
}
