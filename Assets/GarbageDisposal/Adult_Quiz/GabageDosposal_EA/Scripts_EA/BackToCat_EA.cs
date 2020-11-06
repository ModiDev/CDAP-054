using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToCat_EA : MonoBehaviour
{    
    public void BackButton() //link to category page (levels page)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Category_EA");
    }

    public void main() //link to home page
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomePage_EA");
    }

    public void exit() //link to main home page
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GarbageDisposal2Cat");
    }
}
