using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedback_sm : MonoBehaviour
{

    public GameObject smile;
    public bool done = false;

    void Start()
    {

        
    }

    public void check()
    {
        for(int i = 0; i< 4; i++){
            if (transform.GetChild (i).GetComponent<drag_sm> (). on_paste){
                done = true;
            }else {
                done = false;
                i = 4;
            }
        }
        if(done){
            smile.SetActive(true);
                    }

    }

    // Update is called once per frame
    void Update()
    {
        if(!done){
            check();
        }
        
    }
}
