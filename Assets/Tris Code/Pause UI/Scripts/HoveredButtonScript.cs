﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveredButtonScript : MonoBehaviour
{
    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    private float posX1, posX2;
    private float posY1, posY2;


    public GameObject button1;
    public GameObject button2;

    private bool onButton1;
    private bool onButton2;

    void Start()
    {
        onButton1 = false;
        onButton2 = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        posX1 = Mathf.SmoothDamp(transform.position.x, button1.transform.position.x, ref velocity.x, smoothTimeX);
        posY1 = Mathf.SmoothDamp(transform.position.y, button1.transform.position.y, ref velocity.y, smoothTimeY);

        posX2 = Mathf.SmoothDamp(transform.position.x, button2.transform.position.x, ref velocity.x, smoothTimeX);
        posY2 = Mathf.SmoothDamp(transform.position.y, button2.transform.position.y, ref velocity.y, smoothTimeY);

        if (onButton1 == true)
        {
            transform.position = new Vector3(posX1, posY1, transform.position.z);
            onButton2 = false;
        } 
        
        if (onButton2 == true)
        {
            transform.position = new Vector3(posX2, posY2, transform.position.z);
            onButton1 = false;
        }
    }

    public void Button1Open()
    {
        onButton2 = false;
        onButton1 = true;
    }

    public void Button2Open()
    {
        onButton1 = false;
        onButton2 = true;
    }
}
