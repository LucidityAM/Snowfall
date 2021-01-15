using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveredButtonScript : MonoBehaviour
{
    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    private float posX1, posX2, posX3;
    private float posY1, posY2, posY3;


    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    private bool onButton1;
    private bool onButton2;
    private bool onButton3;

    void Start()
    {
        onButton1 = false;
        onButton2 = false;
        onButton3 = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        posX1 = Mathf.SmoothDamp(transform.position.x, button1.transform.position.x, ref velocity.x, smoothTimeX);
        posY1 = Mathf.SmoothDamp(transform.position.y, button1.transform.position.y, ref velocity.y, smoothTimeY);

        posX2 = Mathf.SmoothDamp(transform.position.x, button2.transform.position.x, ref velocity.x, smoothTimeX);
        posY2 = Mathf.SmoothDamp(transform.position.y, button2.transform.position.y, ref velocity.y, smoothTimeY);

        posX3 = Mathf.SmoothDamp(transform.position.x, button3.transform.position.x, ref velocity.x, smoothTimeX);
        posY3 = Mathf.SmoothDamp(transform.position.y, button3.transform.position.y, ref velocity.y, smoothTimeY);

        if (onButton1 == true)
        {
            transform.position = new Vector3(transform.position.x, posY1, transform.position.z);
            onButton2 = false;
            onButton3 = false;
        } 
        
        if (onButton2 == true)
        {
            transform.position = new Vector3(transform.position.x, posY2, transform.position.z);
            onButton1 = false;
            onButton3 = false;
        }

        if(onButton3 == true)
        {
            transform.position = new Vector3(transform.position.x, posY3, transform.position.z);
            onButton1 = false;
            onButton2 = false;
        }
    }

    public void Button1Open()
    {
        onButton3 = false;
        onButton2 = false;
        onButton1 = true;
    }

    public void Button2Open()
    {
        onButton3 = false;
        onButton1 = false;
        onButton2 = true;
    }

    public void Button3Open()
    {
        onButton1 = false;
        onButton2 = false;
        onButton3 = true;
    }

}
