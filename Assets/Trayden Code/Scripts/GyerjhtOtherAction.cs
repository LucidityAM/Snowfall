using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyerjhtOtherAction : MonoBehaviour
{
    public Vector3 finalPos;
    private GameObject player;
    private bool hasPassedThreshold = false;

    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() 
    {
        finalPos = new Vector3(player.transform.position.x, gameObject.transform.position.y);
        if(player.transform.position.x >= 135)
        {
            ActivateGyerjht();
           hasPassedThreshold = true;
        }
        if(hasPassedThreshold == true)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, finalPos, .20f);
        }
    }

    IEnumerator ActivateGyerjht()
    {
        //Monster Noise goes here
        yield return new WaitForSeconds(7.0f);
    }
}
