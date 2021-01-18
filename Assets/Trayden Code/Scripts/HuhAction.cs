using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuhAction : MonoBehaviour
{
    private Vector3 finalPos;
    private GameObject keyItemActionController;
    private GameObject bush;
    private GameObject player;
    public GameObject huh;
    void Start()
    {
        finalPos = new Vector3(17f, huh.transform.position.y, 0);
        keyItemActionController = GameObject.FindGameObjectWithTag("Action Controller");
        bush = GameObject.FindGameObjectWithTag("Bush");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(keyItemActionController.GetComponent<KeyItemActionList>().isInPosition == false)
        {
            huh.transform.position = Vector3.MoveTowards(huh.transform.position, finalPos, 2.35f * Time.deltaTime);
            if(huh.transform.position == finalPos)
            {
                keyItemActionController.GetComponent<KeyItemActionList>().isInPosition = true;
            }
        }
        else if(keyItemActionController.GetComponent<KeyItemActionList>().isInPosition == true)
        {
            if(bush.GetComponent<BushAction>().isHidden == false)
            {
                huh.transform.position = Vector2.MoveTowards(huh.transform.position, player.transform.position, 2.35f * Time.deltaTime);
            }
            else if(bush.GetComponent<BushAction>().isHidden == true)
            {
                huh.transform.position = Vector3.MoveTowards(huh.transform.position, finalPos, 2.35f * Time.deltaTime);
            }

        }
    }
}
