using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialscript_sm : MonoBehaviour
{
    public GameObject textBox;
    void Start()
    {
        StartCoroutine(TheSequence());  
    } 

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Hi, I'm Jake.My facebook account is hacked";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "i have no idea why this happened";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "my friend studies computer security and he told me that this was all my fault.";
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "he asked me to play this game and see what i have done";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "okay then let's play";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "";
    }

    
}
