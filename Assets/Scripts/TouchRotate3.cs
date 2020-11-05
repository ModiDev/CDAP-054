using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate3 : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!GameControl3.youWin3)
            transform.Rotate(0f, 0f, 90f);
    }
}
