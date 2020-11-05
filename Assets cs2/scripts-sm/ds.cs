using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ds : MonoBehaviour
{
  

    public GameObject textBox;
    void Start()
    {
        StartCoroutine(TheSequence());  
    } 

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "1.Min.number of characters in a good password";
        yield return new WaitForSeconds(10);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "2. Something which shouldn't be mentioned in FB";
        yield return new WaitForSeconds(10);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "3.weak passwords consist of";
        yield return new WaitForSeconds(11);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "4.Never share your password with";
        yield return new WaitForSeconds(10);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "5.Details which shouldn't be shared on FB";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
        
    }
}



