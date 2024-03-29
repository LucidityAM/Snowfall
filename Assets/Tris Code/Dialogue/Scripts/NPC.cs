﻿using System.Collections;
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
    public NPCCamera npcCam;
    public float normalSize;
    public float zoomedSize;

    public float duration;
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (dialogueopened == false)
                {
                    dialogueopened = true;
                    dt.StartDialogue();
                    cam.GetComponent<CameraScript>().enabled = false;
                    npcCam.StartCoroutine("FindMidpoint");
                    StartCoroutine(ChangeSize(normalSize, zoomedSize));
                    resetCam = true;
                }
            }

            if (dt.DM.isActive == false)
            {
                //dialogueopened = false;
                if (resetCam == true)
                {
                    StartCoroutine("UpdateCamera");
                    resetCam = false;
                }
                //cam.GetComponent<CameraScript>().enabled = true;
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

    IEnumerator ChangeSize(float Zoom1, float Zoom2)
    {
        float timeElapsed = 0f;

        while(timeElapsed <= duration)
        {
            cam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(Zoom1, Zoom2, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator UpdateCamera()
    {
        cam.GetComponent<CameraScript>().enabled = true;
        npcCam.StartCoroutine("ResetCamera");
        StartCoroutine(ChangeSize(zoomedSize, normalSize));
        yield return new WaitForSeconds(2f);
        dialogueopened = false;
    }
}
