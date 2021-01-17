using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockThrow : MonoBehaviour
{
    public GameObject[] keyItems;
    public bool isActive = false;
    public GameObject[] lights;
    public GameObject monochrome;
    void Start()
    {
        keyItems = GameObject.FindGameObjectsWithTag("Key Item");
        lights = GameObject.FindGameObjectsWithTag("Key Light");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            isActive = !isActive;
            if(isActive)
            {
                monochrome.SetActive(true);
                foreach(GameObject lights in lights)
                {
                    lights.SetActive(true);
                }
                gameObject.GetComponent<SnowballThrow>().enabled = true;
            }
            
        }

        if(isActive == false)
        {
            foreach (GameObject lights in lights)
            {
                lights.SetActive(false);
            }
            monochrome.SetActive(false);
            gameObject.GetComponent<SnowballThrow>().enabled = false;
        }
    }
}
