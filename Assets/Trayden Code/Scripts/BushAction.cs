using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushAction : MonoBehaviour
{
    public bool isHidden = false;
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isHidden = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isHidden = false;
        }
    }
}
