using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTrigger dt;
    public GameObject prompt;

    private Animator promptAnim;

    public bool promptopened;
    public bool dialogueopened;
    // Start is called before the first frame update
    void Start()
    {
        promptAnim = prompt.GetComponent<Animator>();
        promptopened = false;
        dialogueopened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (promptopened == true)
        {
            if (Input.GetKey(KeyCode.L))
            {
                if (dialogueopened == false)
                {
                    dt.StartDialogue();
                    dialogueopened = true;
                }
            }
        }

        if(dt.DM.isActive == false)
        {
            dialogueopened = false;
        }
    }
    public IEnumerator OpenPromptDialogue()
    {
        prompt.SetActive(true);
        promptAnim.SetTrigger("isOpen");
        yield return null;
    }

    public IEnumerator ClosePromptDialogue()
    {
        promptAnim.SetTrigger("isOpen");
        yield return new WaitForSeconds(0.4f);
        promptopened = false;
        dialogueopened = false;
        prompt.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine("ClosePromptDialogue");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (promptopened == false)
            {
                StartCoroutine("OpenPromptDialogue");
                promptopened = true;
            }
        }
    }

}
