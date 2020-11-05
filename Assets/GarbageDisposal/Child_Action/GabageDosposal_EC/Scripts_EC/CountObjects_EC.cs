using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountObjects_EC : MonoBehaviour  // Count of the objects and Change next scene
{
    public string next;
    public GameObject objToDestroy;
    GameObject objUI; 

    void Start()
    {
        objUI = GameObject.Find("ObjectNum");
    }
    void Update()
    {
        objUI.GetComponent<Text>().text = ObjectsToCollect_EC.objects.ToString();
        if(ObjectsToCollect_EC.objects == 0)
        {
            Application.LoadLevel("LevelsPage_EC");
            //Destroy(objToDestroy);
           // objUI.GetComponent<Text>().text = "All Objects Collected";
        }
    }
}
