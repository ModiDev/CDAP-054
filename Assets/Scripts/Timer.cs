using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    
    public Text timerText;
    private float startTime;
    private bool Finnished = false;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Finnished)
            return;
        float t = Time.time - startTime;
        string miniutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = miniutes + ":" + seconds;
    }
    public void Finnish()
    {
        Finnished = true;
        timerText.color = Color.yellow;
    }
}
