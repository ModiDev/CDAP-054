using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialscript3_sm : MonoBehaviour
{
    public GameObject textBox;
    void Start()
    {
        StartCoroutine(TheSequence());  
    } 

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "OMG, now i understand what i have done";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "My friend is right.it was all my fault";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "I haven't used a proper password and my password was weak.";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "I have done most of the things they have said not to do.";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "But now i'm aware of it";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
         yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "So let's move on to see  how much i will score";
          yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "";
    }

    
}
