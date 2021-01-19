using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowpileOtherAction : MonoBehaviour
{
    public GameObject gyerjht;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject == gyerjht && gameObject.transform.position.y > -1.5f)
        {
            gyerjht.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
