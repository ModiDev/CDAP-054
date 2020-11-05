using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RSP_L2NNMoveSeane : MonoBehaviour
{
    [SerializeField] private string RSP_loadLevel;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(RSP_loadLevel);
        }
    }
}
