using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemActionList : MonoBehaviour
{
    public GameObject beehive;
    public GameObject huh;
    public GameObject huhAction;
    public GameObject gyerjht;
    public GameObject snowpile;
    public GameObject player;
    public bool isInPosition = false;
    IEnumerator BeehiveAction()
    {
        Vector3 finalPos = new Vector3(beehive.transform.position.x, -1.87f, 0);
        Vector3 velocity = Vector3.zero;
        while(beehive.transform.position != finalPos)
        {
            beehive.transform.position = Vector3.SmoothDamp(beehive.transform.position, finalPos, ref velocity, .15f, Mathf.Infinity, Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator HuhAction()
    {
        huhAction.SetActive(true);
        yield return null;
    }
    IEnumerator GyerjhtAction()
    {
        gyerjht.GetComponent<GyerjhtOtherAction>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        gyerjht.GetComponent<GyerjhtOtherAction>().enabled = true;
    }

    IEnumerator SnowpileAction()
    {
        Vector3 finalPos = new Vector3(snowpile.transform.position.x, -1.9f, 0);
        Vector3 velocity = Vector3.zero;
        while(snowpile.transform.position != finalPos)
        {
            snowpile.transform.position = Vector3.SmoothDamp(snowpile.transform.position, finalPos, ref velocity, .15f, Mathf.Infinity, Time.deltaTime);
            yield return null;
        }
    }
}