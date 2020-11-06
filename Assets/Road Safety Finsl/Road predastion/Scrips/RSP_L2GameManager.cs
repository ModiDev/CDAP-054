using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

//Manage game..
public class RSP_L2GameManager : MonoBehaviour
{
    public static RSP_L2GameManager instance = null;

    public GameObject scoreTextObject;

    int score;
    Text scoreText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy (gameObject);  //Destroy Objects

        scoreText = scoreTextObject.GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();   //Call Score
    }

    public void Collect(int passedValue, GameObject passedObject)
    {
        passedObject.GetComponent<Renderer>().enabled = false;
        passedObject.GetComponent<Collider>().enabled = false;
        Destroy (passedObject, 1.0f); 
        score = score + passedValue;  //Calculate Score
        scoreText.text = "Score: " + score.ToString(); //Display Score
    }
}
