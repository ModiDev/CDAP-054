using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate1 : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!GameControl1.youWin1)
            transform.Rotate(0f, 0f, 90f);
    }
}
