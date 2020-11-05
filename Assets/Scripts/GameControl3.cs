using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl3 : MonoBehaviour
{
    [SerializeField]
    private Transform[] symptoms;

    [SerializeField]
    private GameObject winText3;

    public static bool youWin3;
    // Start is called before the first frame update
    void Start()
    {
        winText3.SetActive(false);
        youWin3 = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (symptoms[0].rotation.z == 0 &&
         symptoms[1].rotation.z == 0 &&
          symptoms[2].rotation.z == 0 &&
          symptoms[3].rotation.z == 0 &&
          symptoms[4].rotation.z == 0 &&
          symptoms[5].rotation.z == 0 &&
          symptoms[6].rotation.z == 0 &&
          symptoms[7].rotation.z == 0 &&
          symptoms[8].rotation.z == 0 &&
          symptoms[9].rotation.z == 0 &&
          symptoms[10].rotation.z == 0 &&
          symptoms[11].rotation.z == 0 )
        {
            youWin3 = true;
            winText3.SetActive(true);
        }
    }
}

