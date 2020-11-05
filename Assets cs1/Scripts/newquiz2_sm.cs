using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newquiz2_sm : MonoBehaviour
{
   public GameObject feed_happy, feed_sad;
    // Start is called before the first frame update
    void Start()
    {
         PlayerPrefs.SetInt("score" , 0);
    }

    public void answer(bool newquiz2_sm)
    {
        if (newquiz2_sm)
        {
            feed_happy.SetActive(false);
            feed_happy.SetActive(true);
            int score = PlayerPrefs.GetInt("score") + 10;
            PlayerPrefs.SetInt("score" , score);

        }

        else
        {
            feed_sad.SetActive(false);
            feed_sad.SetActive(true);
        }

        gameObject.SetActive(false);
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex () +1).gameObject.SetActive(true);
    }

    void Update()
    {
        
    }
}
