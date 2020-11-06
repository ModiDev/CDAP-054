using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Open Panels Using Button
public class RSDPanelOpen : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}
