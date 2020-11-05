using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate2 : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!GameControl2.youWin2)
            transform.Rotate(0f, 0f, 90f);
    }
}
