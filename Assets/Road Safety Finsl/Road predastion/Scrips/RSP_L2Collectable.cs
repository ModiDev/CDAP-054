using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class RSP_L2Collectable : MonoBehaviour
{
    public int value;
    public float rotateSpeed;

    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }

    void OnTriggerEnter()
    {
        RSP_L2GameManager.instance.Collect(value, gameObject);

        AudioSource source = GetComponent<AudioSource> ();
        source.Play();
    }
}
