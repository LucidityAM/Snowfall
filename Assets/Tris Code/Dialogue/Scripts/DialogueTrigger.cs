using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager DM;

    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isActive = DM.isActive;
    }

    public void StartDialogue()
    {
        DM.StartCoroutine("StartDialogue", dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartDialogue();
        Destroy(this, 0);
    }
}
