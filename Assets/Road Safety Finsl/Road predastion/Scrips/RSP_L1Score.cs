//using System.Collections;
//using System.Collections.Generic;
//using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI; 

public class RSP_L1Score : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;
    
    void Update()
    {
        scoreText.GetComponent<Text>().text = "SCORE:" + theScore;
    }
}
