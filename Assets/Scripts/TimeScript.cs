using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeScript : MonoBehaviour
{
    Image timeBar;
    public float maxTime = 5f;
    float timeLeft;
    public GameObject timeUpText;
    void Start()
    {
        timeUpText.SetActive(false);
        timeBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
            
        }
        else
        {
            timeUpText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
