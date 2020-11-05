using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class D2Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Level3");
    }
}
