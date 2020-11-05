using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoiceScript3 : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public int ChoiceMade;

    public void ChoiceOption1()
    {
        TextBox.GetComponent<Text>().text = "Wrong!!! That is not a correct decision";
        ChoiceMade = 1;
    }
    
    public void ChoiceOption2()
    {
        TextBox.GetComponent<Text>().text = "Correct!!! Excellent -That is the best idea";
        ChoiceMade = 2;
    }
    public void ChoiceOption3()
    {
        TextBox.GetComponent<Text>().text = "Wrong!!! Please do the memorizing part correctly";
        ChoiceMade = 3;
    }

    void Update()
    {
        if (ChoiceMade >= 1)
        {
            Choice01.SetActive(false);
            Choice02.SetActive(false);
            Choice03.SetActive(false);
        }
    }
}
