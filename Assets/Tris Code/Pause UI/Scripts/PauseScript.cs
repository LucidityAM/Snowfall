using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject fakepauseBG;
    public GameObject realpauseBG;

    private Animator fakepauseBGAnim;


    #region Things that need to be turned off
    public GameObject player;
    private PlayerMovement playerMovement;
    private Rigidbody2D playerRB;
    private Animator playerAnim;
    #endregion

    private bool paused;

    void Awake()
    {
        paused = false;
        PauseConditions.fakeside = true;

        fakepauseBG.SetActive(false);
        realpauseBG.SetActive(false);

        #region Components
        fakepauseBGAnim = fakepauseBG.GetComponent<Animator>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerRB = player.GetComponent<Rigidbody2D>();
        playerAnim = player.GetComponent<Animator>();
        #endregion
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            if (PauseConditions.fakeside == true)
            {
                StartCoroutine("FakeOpenMenu");
            }
            else
            {
                StartCoroutine("RealOpenMenu");
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            if (PauseConditions.fakeside == true)
            {
                StartCoroutine("FakeCloseMenu");
            }
            else
            {
                StartCoroutine("RealCloseMenu");
            }
        }
    }

    public void StartEnumerator(string name)
    {
        StopAllCoroutines();
        StartCoroutine(name);
    }

    //OKOKOK listen.... I really messed up with the code for this one ok. I didnt think too much about implementation of the REAL UI until i got to that point.
    //So I will now use 2 sets of 2 methods to do the exact same thing!
    public IEnumerator FakeOpenMenu()
    {
        paused = true;
        ToggleScripts();
        yield return new WaitForSeconds(0.1f);
        fakepauseBG.SetActive(true);
        fakepauseBGAnim.SetBool("IsOpen", true);
    }

    public IEnumerator FakeCloseMenu()
    {
        paused = false;
        ToggleScripts();
        fakepauseBGAnim.SetBool("IsOpen", false);
        yield return new WaitForSeconds(0.2f);
        fakepauseBG.SetActive(false);
        yield return new WaitForSeconds(0.1f);
    }
    public IEnumerator RealOpenMenu()
    {
        paused = true;
        ToggleScripts();
        yield return new WaitForSeconds(0.1f);
        realpauseBG.SetActive(true);
    }

    public IEnumerator RealCloseMenu()
    {
        paused = false;
        ToggleScripts();
        yield return new WaitForSeconds(0.2f);
        realpauseBG.SetActive(false);
        yield return new WaitForSeconds(0.1f);
    }

    public void ToggleScripts()
    {
        playerMovement.enabled = !playerMovement.isActiveAndEnabled;
        playerAnim.enabled = !playerAnim.enabled;
        if (paused == true)
        {
            playerRB.velocity = new Vector3(0, 0, 0);
            playerRB.bodyType = RigidbodyType2D.Static;
        } else
        {
            playerRB.bodyType = RigidbodyType2D.Dynamic;
        }
    
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC Idle");
        Animator[] npcScripts = new Animator[npcs.Length];
        for(int i = 0; i < npcs.Length; i++)
        {
            npcScripts[i] = npcs[i].GetComponent<Animator>();
        }

        foreach(Animator anim in npcScripts)
        {
            anim.enabled = !anim.enabled;
        }
    

    }
}
