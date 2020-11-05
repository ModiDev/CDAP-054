﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RSP_Distription : MonoBehaviour
{
    public GameObject UiObject;
    //public GameObject Item;

    void Start()
    {
        UiObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UiObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        UiObject.SetActive(false);
        //Destroy(Item);
    }
}
