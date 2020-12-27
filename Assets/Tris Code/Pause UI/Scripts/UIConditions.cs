using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConditions : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fake")
        {
            PauseConditions.fakeside = true;
        } else if (collision.gameObject.tag == "Real")
        {
            PauseConditions.fakeside = false;
        }

    }
}
