 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl1 : MonoBehaviour
{
    [SerializeField]
    private Transform[] dengue;

    [SerializeField]
    private GameObject winText1;

    public static bool youWin1;
    // Start is called before the first frame update
    void Start()
    {
        winText1.SetActive(false);
        youWin1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dengue[0].rotation.z == 0 &&
          dengue[1].rotation.z == 0 &&
          dengue[2].rotation.z == 0 &&
          dengue[3].rotation.z == 0)
        {
            youWin1 = true;
            winText1.SetActive(true);
        }
    }
}
