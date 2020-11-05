using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class D4Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Level5");
    }
}
