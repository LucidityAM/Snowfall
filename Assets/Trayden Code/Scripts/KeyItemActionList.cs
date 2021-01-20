using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemActionList : MonoBehaviour
{
    public GameObject beehive;
    public GameObject beehive2;
    public GameObject beehive3;
    public GameObject huh;
    public GameObject huhAction;
    public GameObject gyerjht;
    public Animator gyerjhtAnim;
    private bool isStunned = false;
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
    IEnumerator Beehive2Action()
    {
        Vector3 finalPos = new Vector3(beehive2.transform.position.x, -1.87f, 0);
        Vector3 velocity = Vector3.zero;
        while(beehive2.transform.position != finalPos)
        {
            beehive2.transform.position = Vector3.SmoothDamp(beehive2.transform.position, finalPos, ref velocity, .15f, Mathf.Infinity, Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator Beehive3Action()
    {
        Vector3 finalPos = new Vector3(beehive3.transform.position.x, -1.87f, 0);
        Vector3 velocity = Vector3.zero;
        while(beehive3.transform.position != finalPos)
        {
            beehive3.transform.position = Vector3.SmoothDamp(beehive3.transform.position, finalPos, ref velocity, .15f, Mathf.Infinity, Time.deltaTime);
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
        if(isStunned == false)
        {
            isStunned = true;
            gyerjht.GetComponent<GyerjhtOtherAction>().enabled = false;
            gyerjhtAnim.SetBool("isStunned", true);
            yield return new WaitForSeconds(1.5f);
            gyerjhtAnim.SetBool("isStunned", false);
            gyerjht.GetComponent<GyerjhtOtherAction>().enabled = true;
            isStunned = false;
        }
        else
        {
            yield return null;
        }
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