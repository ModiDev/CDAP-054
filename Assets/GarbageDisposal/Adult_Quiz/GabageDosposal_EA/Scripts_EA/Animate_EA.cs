using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animate_EA : MonoBehaviour
{
    public GameObject right, wrong;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void aminate(bool anime)
    {
        if (anime)
        {
            right.SetActive(false);
            right.SetActive(true);
            int score = PlayerPrefs.GetInt("score") + 10;
            PlayerPrefs.SetInt("score", score);
        }
        else
        {
            wrong.SetActive(false);
            wrong.SetActive(true);
        }
        gameObject.SetActive(false);
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
          
    }
}

