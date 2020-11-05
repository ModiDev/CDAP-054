using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpen_EC : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update

    public void OpenPanel()
    {
        if(Panel!=null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
