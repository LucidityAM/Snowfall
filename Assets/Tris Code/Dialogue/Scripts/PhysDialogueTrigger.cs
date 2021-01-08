using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager DM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DM.StartCoroutine("StartDialogue", dialogue);
            Destroy(gameObject, 0);
        }
    }
}
