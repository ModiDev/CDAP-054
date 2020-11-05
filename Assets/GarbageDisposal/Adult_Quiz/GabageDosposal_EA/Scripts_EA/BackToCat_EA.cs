using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToCat_EA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Go to categories
    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Category_EA");
    }

    public void main()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomePage_EA");
    }

    public void exit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GarbageDisposal2Cat");
    }
}
