using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    
    void OnTriggerEnter(Collider plyr)
    {
       
     SceneManager.LoadScene(1);
    }
    
}
