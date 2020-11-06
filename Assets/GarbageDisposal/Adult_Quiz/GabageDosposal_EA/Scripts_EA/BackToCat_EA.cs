using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToCat_EA : MonoBehaviour
{    
    public void BackButton() //Go to categories (levels page)
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
