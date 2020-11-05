using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class categoryGD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameQuiz()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomePage_EA");
    }

    public void gameAction()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomePage_EC");
    }
}
