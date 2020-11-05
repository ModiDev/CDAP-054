using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_sm : MonoBehaviour
{

    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int order = 0;
    void active(int a){
        order += a;
        if(order < 0){
            order = parent.transform.childCount - 1;

        }
        else if (order > parent.transform.childCount){
            order = 0;



        }
        for(int i = 0; i< parent.transform.childCount; i++){
            parent.transform.GetChild (i).gameObject.SetActive(false);

        }
        parent.transform.GetChild(order).gameObject.SetActive(true);
    }


    void OnMouseUp(){
        if(gameObject.name == "next"){
            active(1);
        }else{
            active(-1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
