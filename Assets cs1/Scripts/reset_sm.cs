using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset_sm : MonoBehaviour
{
    public GameObject parent_puzzle, smile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseUp(){
        for(int i = 0; i< 4; i++){
           parent_puzzle.transform.GetChild (i).GetComponent<drag_sm> (). on_paste = false;
           parent_puzzle.transform.GetChild (i).GetComponent<drag_sm> (). on_pos = false;
           parent_puzzle.transform.GetChild (i).position = parent_puzzle.transform.GetChild (i). GetComponent<drag_sm>().pos_awal;
            parent_puzzle.transform.GetChild (i).localScale = parent_puzzle.transform.GetChild (i). GetComponent<drag_sm>().scale_awal;
    }
    smile.SetActive (false);
    parent_puzzle.GetComponent<feedback_sm> ().done = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
