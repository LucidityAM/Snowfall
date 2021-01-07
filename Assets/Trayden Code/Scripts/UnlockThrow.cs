using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockThrow : MonoBehaviour
{
    public GameObject[] keyItems;
    public bool isActive = false;

    public GameObject[] lights = new GameObject[10];

    public GameObject monochrome;

    void Start()
    {
        keyItems = GameObject.FindGameObjectsWithTag("Key Item");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            isActive = !isActive;
            if(isActive)
            {
                monochrome.SetActive(true);

                foreach(GameObject keyItem in keyItems)
                {
                    foreach(GameObject lights in lights)
                    {
                        lights.SetActive(true);
                    }
                }
                gameObject.GetComponent<SnowballThrow>().enabled = true;
            }
            
        }

        if(isActive == false)
        {
            foreach (GameObject keyItem in keyItems)
            {
                foreach (GameObject lights in lights)
                {
                    lights.SetActive(false);
                }
            }
            monochrome.SetActive(false);

            gameObject.GetComponent<SnowballThrow>().enabled = false;
        }
    }
}
