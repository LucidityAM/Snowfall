using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemActionList : MonoBehaviour
{
    IEnumerator KeyItem1Action()
    {
        Debug.Log("Action 1 Completed");
        yield return null;
    }

    IEnumerator KeyItem2Action()
    {
        Debug.Log("Action 2 Completed");
        yield return null;
    }
}
