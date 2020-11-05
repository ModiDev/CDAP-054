using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menustart : MonoBehaviour
{
    public void changemenuscene(string scenename)
    {
        Application. LoadLevel(scenename);
    }
    
}
