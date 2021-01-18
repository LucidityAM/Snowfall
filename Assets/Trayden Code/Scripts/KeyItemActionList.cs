using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemActionList : MonoBehaviour
{
    public GameObject beehive;
    public GameObject beeSwarm;
    public GameObject huh;
    public GameObject huhAction;
    public GameObject gyerjht;
    public GameObject snowpile;
    public bool isInPosition = false;
    IEnumerator BeehiveAction()
    {
        Instantiate(beeSwarm, beehive.transform.position, Quaternion.identity);
        beehive.gameObject.SetActive(false);
        yield return null;
    }
    IEnumerator HuhAction()
    {
        huhAction.SetActive(true);
        yield return null;
    }
    IEnumerator GyerjhtAction()
    {
        yield return null;
    }

    IEnumerator SnowpileAction()
    {
        yield return null;
    }
}