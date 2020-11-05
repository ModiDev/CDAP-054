using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSDAnimateFeedback : MonoBehaviour
{
    public GameObject right, wrong;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("Score", 0);
    }

    public void aminate(bool anime)
    {
        if (anime)
        {
            right.SetActive(false);
            right.SetActive(true);
            int score = PlayerPrefs.GetInt("Score") + 50;
            PlayerPrefs.SetInt("Score", score);

            gameObject.SetActive(false);
            transform.parent.GetChild(gameObject.transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
        }
        else
        {
            wrong.SetActive(false);
            wrong.SetActive(true);
            int score = PlayerPrefs.GetInt("Score") - 20;
            PlayerPrefs.SetInt("Score", score);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
