using System.Collections;
using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Threading;
using UnityEngine;

public class ObjectsToCollect_EC : MonoBehaviour  //Collect objects , Rotate objects
{ 
    public static int objects = 0;
    public float rotateSpeed;
    public int value;

    void Awake()
    {
        objects++;
    }

    void OnTriggerEnter(Collider plyr)
    {
        if(plyr.gameObject.tag == "Player")
        {
            objects--;
            gameObject.SetActive(false);
        }
        GameManager.instance.Collect(value, gameObject);


    }

  /*  void OnTriggerEnter()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }
}
