using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class D3Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Level4");
    }
}
