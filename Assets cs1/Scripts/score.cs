using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{
 
    void Start()
    {
         PlayerPrefs.SetInt("score" , 0);
    }

   
    void Update()
    {
        GetComponent<Text> ().text = PlayerPrefs.GetInt("score").ToString();
    }
}

