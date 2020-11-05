using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene_onkeypress_sm : MonoBehaviour
{
    [SerializeField] private string newlevel;
    [SerializeField] private GameObject uiElement;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            uiElement.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(newlevel);
            
            }
        }
    }
    private void OnTriggerExit(Collider other)
{
    if(other.CompareTag("Player"))
    {
        uiElement.SetActive(false);
    }
}
    

}