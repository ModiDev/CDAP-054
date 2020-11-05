﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_EA : MonoBehaviour
{
    float scrollSpeed = -0.5f;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 20);
        transform.position = startPos + Vector2.right * newPos;
    }
}
