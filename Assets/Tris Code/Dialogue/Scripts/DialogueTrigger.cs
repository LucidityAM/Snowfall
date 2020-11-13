using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject player;
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().StartCoroutine("StartDialogue", dialogue);
    }


}
