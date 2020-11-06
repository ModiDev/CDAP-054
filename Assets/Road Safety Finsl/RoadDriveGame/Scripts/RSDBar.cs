using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

//Object animation method
public class RSDBar : MonoBehaviour
{
    public GameObject bar;
    public int time;

    void Start()
    {
        AnimateBar(); //Object Animation
    }

    void Update()
    {

    }

    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 1, time);
    }
}
