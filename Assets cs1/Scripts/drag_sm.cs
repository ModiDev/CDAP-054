using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_sm : MonoBehaviour
{
    public GameObject  detector;
    public Vector3 pos_awal , scale_awal;
    public bool on_pos = false , on_paste = false;

    // Start is called before the first frame update
    void Start()
    {
        pos_awal = transform.position;
        scale_awal = transform.localScale;
    }

    void OnMouseDrag()
    {
        Vector3 pos_mouse = Camera.main. ScreenToWorldPoint ( new Vector3 (Input.mousePosition.x, Input.mousePosition.y,Input.mousePosition.z));
        transform.position = new Vector3(pos_mouse.x, pos_mouse.y, -1f);
        transform.localScale = new Vector3(0.4f,0.4f);

    }


    void OnMouseUp()
    {
        if (on_pos){
            transform.position = detector.transform.position;
            transform.localScale = new Vector3(0.4f,0.4f);
            on_paste = true;

        }
        else
        {
            transform.position = pos_awal;
            transform.localScale = scale_awal;
            on_paste = false;
        }
    }

    void OnTriggerStay2D(Collider2D objek)
    {
        if(objek.gameObject == detector)
        {
            on_pos = true ;


        }
    }

     void OnTriggerExit2D(Collider2D objek)
    {
        if(objek.gameObject == detector)
        {
            on_pos = false ;
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

