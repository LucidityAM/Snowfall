using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDisable : MonoBehaviour
{
    private CameraScript cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
        cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cam.enabled = false;
        }
    }

}
