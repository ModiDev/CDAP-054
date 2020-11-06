using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSP_PanelOpen : MonoBehaviour
{
    public GameObject Panel;

//Using Open Panels..
    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf; //Click Button and open Panels
            Panel.SetActive(!isActive);
        }
    }
}
