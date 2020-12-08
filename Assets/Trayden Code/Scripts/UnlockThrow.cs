using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockThrow : MonoBehaviour
{
    public GameObject[] keyItems;
    public bool isActive = false;
    void Start()
    {
        keyItems = GameObject.FindGameObjectsWithTag("Key Item");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            isActive = !isActive;
            if(isActive == true)
            {
                //Camera becomes monochromatic here
                foreach(GameObject keyItem in keyItems)
                {
                    //GameObject lighting gets activated here
                }
                gameObject.GetComponent<SnowballThrow>().enabled = true;
            }
            else
            {
                //Camera becomes resaturated here
                foreach(GameObject keyItem in keyItems)
                {
                    //GameObject lighting gets disabled here
                }
                gameObject.GetComponent<SnowballThrow>().enabled = false;
            }
        }
    }
}
