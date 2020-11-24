using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTrigger dt;
    public GameObject prompt;

    private Animator promptAnim;
    // Start is called before the first frame update
    void Start()
    {
        promptAnim = prompt.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            StartCoroutine("OpenPromptDialogue");
            if (Input.GetKeyDown(KeyCode.L))
            {
                dt.StartDialogue();
            }
        }
    }

}
