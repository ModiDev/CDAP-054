using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Object selected..
public class RSP_L1CollCoCorr : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        collectSound.Play(); //Object collected sound
        RSP_L1Score.theScore -= 50; //Marks are deducted
        Destroy(gameObject); // And Destroy Objects

    }
}
