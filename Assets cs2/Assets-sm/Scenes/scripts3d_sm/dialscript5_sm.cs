using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialscript5_sm : MonoBehaviour
{
    public GameObject textBox;
    void Start()
    {
        StartCoroutine(TheSequence());  
    } 

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "wow,it was nice";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Okay friends just a small reminder for you all before i leave";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Never use weak passwords nor share unnecessary stuff on facebook";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Good bye!!!";
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "";
       
    }

    
}
