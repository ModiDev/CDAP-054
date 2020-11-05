using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWrong_EC : MonoBehaviour // Collect wrong objects
{

    public float rotateSpeed;
    public int value;

    void OnTriggerEnter()
    {
        GameManager.instance.Collect(value, gameObject);
    }

    void Update()
    {
       gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }
}
