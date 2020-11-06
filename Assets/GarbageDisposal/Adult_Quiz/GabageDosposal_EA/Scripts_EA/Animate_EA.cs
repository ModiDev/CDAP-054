using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animate_EA : MonoBehaviour   //popup animation by clicking wrong or correct answer
{
    public GameObject right, wrong;  
    
    public void aminate(bool anime) //when clicking right answer
    {
        if (anime)
        {
            right.SetActive(false);
            right.SetActive(true);
            int score = PlayerPrefs.GetInt("score") + 10;
            PlayerPrefs.SetInt("score", score);
        }
        else                                //when clicking wrong answer
        {
            wrong.SetActive(false);
            wrong.SetActive(true);
        }
        gameObject.SetActive(false);
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
    }
}

