using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectcoins : MonoBehaviour
{
    public AudioSource collectSound;
    

    void Update()
    {
        transform.Rotate(90 * Time.deltaTime,0 , 0);
    }
    void OnTriggerEnter(Collider Other)
    {
        collectSound.Play();
        ScoringSystem.theScore += 5;
        Destroy(gameObject);
    }
}
