using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemActionList : MonoBehaviour
{
    public GameObject keyItem1;
    IEnumerator KeyItem1Action()
    {
        keyItem1.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(.75f);
        keyItem1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return null;
    }

    IEnumerator KeyItem2Action()
    {
        Debug.Log("Action 2 Completed");
        yield return null;
    }
}
