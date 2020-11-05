using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RSP_SceneChanger : MonoBehaviour
{
    public string SceneName;
    void Start()
    {

    }
    void UIpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    public void ChangeLevel(string SceneName)
    {
        SceneManager.LoadScene(SceneName);    }
}
