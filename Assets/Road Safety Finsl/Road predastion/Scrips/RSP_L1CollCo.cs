using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSP_L1CollCo : MonoBehaviour
{
    public AudioSource collectSound;

     
    void OnTriggerEnter(Collider other)
    {
        collectSound.Play(); //Object collected sound
        RSP_L1Score.theScore += 50; //Add Marks Select object 
        Destroy(gameObject); //Destroy Object

    }
}
