using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl2 : MonoBehaviour
{

    [SerializeField]
    private Transform[] dengue1;

    [SerializeField]
    private GameObject winText2;

    public static bool youWin2;
    // Start is called before the first frame update
    void Start()
    {
        winText2.SetActive(false);
        youWin2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dengue1[0].rotation.z == 0 &&
        dengue1[1].rotation.z == 0 &&
        dengue1[2].rotation.z == 0 &&
        dengue1[3].rotation.z == 0 &&
        dengue1[4].rotation.z == 0 &&
        dengue1[5].rotation.z == 0)
        {
            youWin2 = true;
            winText2.SetActive(true);
        }
    }
}
