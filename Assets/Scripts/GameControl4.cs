using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl4 : MonoBehaviour
{
    [SerializeField]
    private Transform[] recover;

    [SerializeField]
    private GameObject winText4;

    public static bool youWin4;
    // Start is called before the first frame update
    void Start()
    {
        winText4.SetActive(false);
        youWin4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (recover[0].rotation.z == 0 &&
            recover[1].rotation.z == 0 &&
            recover[2].rotation.z == 0 &&
            recover[3].rotation.z == 0 &&
            recover[4].rotation.z == 0 &&
            recover[5].rotation.z == 0 &&
            recover[6].rotation.z == 0 &&
            recover[7].rotation.z == 0 &&
            recover[8].rotation.z == 0 &&
            recover[9].rotation.z == 0 &&
            recover[10].rotation.z == 0 &&
            recover[11].rotation.z == 0 &&
            recover[12].rotation.z == 0 &&
            recover[13].rotation.z == 0 &&
            recover[14].rotation.z == 0 &&
            recover[15].rotation.z == 0 &&
            recover[16].rotation.z == 0 &&
            recover[17].rotation.z == 0 &&
            recover[18].rotation.z == 0 &&
            recover[19].rotation.z == 0
            )
        {
            youWin4 = true;
            winText4.SetActive(true);
        }
    }
}
