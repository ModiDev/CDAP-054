using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDestroy : MonoBehaviour
{
   void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
