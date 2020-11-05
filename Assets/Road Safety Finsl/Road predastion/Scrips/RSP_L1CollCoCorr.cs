using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSP_L1CollCoCorr : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        RSP_L1Score.theScore -= 50;
        Destroy(gameObject);

    }
}
