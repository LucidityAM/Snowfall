using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTrigger dt;
    public GameObject prompt;

    private Animator promptAnim;

    private bool promptopened;
    private bool dialogueopened;

    private GameObject cam;

    #region Camera Lerping Variables
    public float Zoom1;
    public float Zoom2;

    public float duration;
    private float elapsed = 0.0f;
    private bool resetCam;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        promptAnim = prompt.GetComponent<Animator>();
        promptopened = false;
        dialogueopened = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        resetCam = false;
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
                    elapsed = 0.0f;
                    elapsed += Time.deltaTime / duration;
                    cam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(Zoom1, Zoom2, elapsed);
                    cam.GetComponent<CameraScript>().enabled = false;
                    cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 1f, cam.transform.position.z);
                    resetCam = true;
                }
            }

            if (dt.DM.isActive == false)
            {
                dialogueopened = false;
                elapsed = 0.0f;
                elapsed += Time.deltaTime / duration;
                cam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(Zoom2, Zoom1, elapsed);
                cam.GetComponent<CameraScript>().enabled = true;
                
                if(resetCam == true)
                {
                    cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 1f, cam.transform.position.z);
                    resetCam = false;
                }
            }
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
