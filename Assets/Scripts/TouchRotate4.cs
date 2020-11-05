using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate4 : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!GameControl4.youWin4)
            transform.Rotate(0f, 0f, 90f);
    }
}
