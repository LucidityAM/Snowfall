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
    public GameObject fluffy;
    public AudioSource audio;
    private PlayerMovement playerMovement;
    private Rigidbody2D playerRB;
    private Animator playerAnim;

    public AudioClip openSound;
    public AudioClip closeSound;
    #endregion


    #region enemy disabling
    public GameObject gyerjht;
    public HuhAction huh;
    public Animator huhAnim;
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
            else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
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
        if (audio != null)
        {
            audio.clip = openSound;
            audio.Play();
        }
        yield return new WaitForSeconds(0.1f);
        fakepauseBG.SetActive(true);
        fakepauseBGAnim.SetBool("IsOpen", true);
        ToggleScripts();
        yield return new WaitForSeconds(.2f);
    }

    public IEnumerator FakeCloseMenu()
    {
        paused = false;
        if (audio != null)
        {
            audio.clip = closeSound;
            audio.Play();
        }
        fakepauseBGAnim.SetBool("IsOpen", false);
        yield return new WaitForSeconds(0.2f);
        fakepauseBG.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        ToggleScripts();
        yield return new WaitForSeconds(.2f);
    }
    public IEnumerator RealOpenMenu()
    {
        paused = true;
        yield return new WaitForSeconds(0.1f);
        realpauseBG.SetActive(true);
        ToggleScripts();
        yield return new WaitForSeconds(.2f);
    }

    public IEnumerator RealCloseMenu()
    {
        paused = false;
        realpauseBG.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        ToggleScripts();
        yield return new WaitForSeconds(.2f);
    }

    public void ToggleScripts()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC Idle");
        Animator[] npcAnims = new Animator[npcs.Length];
        NPC[] npcScripts = new NPC[npcs.Length];
        DialogueTrigger[] dialogues = FindObjectsOfType<DialogueTrigger>();
        PhysDialogueTrigger[] physDialogues = FindObjectsOfType<PhysDialogueTrigger>();

        for (int i = 0; i < npcs.Length; i++)
        {
            npcAnims[i] = npcs[i].GetComponent<Animator>();
            npcScripts[i] = npcs[i].GetComponent<NPC>();
        }

        for(int i = 0; i < dialogues.Length; i++)
        {
            dialogues[i].enabled = !dialogues[i].enabled;
        }

        foreach(PhysDialogueTrigger trigger in physDialogues)
        {
            trigger.enabled = !trigger.enabled;
        }

        foreach (Animator anim in npcAnims)
        {
            if (anim != null)
            {
                anim.enabled = !anim.enabled;
            }
        }

        foreach (NPC npc in npcScripts)
        {
            if (npc != null)
            {
                npc.enabled = !npc.enabled;
            }
        }

        if (paused == true)
        {
            playerRB.velocity = new Vector3(0, 0, 0);
            playerRB.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            playerRB.bodyType = RigidbodyType2D.Dynamic;
        }

        playerMovement.enabled = !playerMovement.isActiveAndEnabled;
        playerAnim.enabled = !playerAnim.enabled;
        if(FindObjectOfType<UnlockThrow>() != null)
        {
            FindObjectOfType<UnlockThrow>().enabled = !FindObjectOfType<UnlockThrow>().enabled;
        }
        if (fluffy != null)
        {
            fluffy.GetComponent<Animator>().enabled = !fluffy.GetComponent<Animator>().enabled;
            fluffy.GetComponent<FluffyMovement>().enabled = !fluffy.GetComponent<FluffyMovement>().enabled;
        }
        if(gyerjht != null)
        {
            gyerjht.GetComponent<Animator>().enabled = !gyerjht.GetComponent<Animator>().enabled;
            gyerjht.GetComponent<GyerjhtOtherAction>().enabled = !gyerjht.GetComponent<GyerjhtOtherAction>().enabled;
            huhAnim.enabled = !huhAnim.enabled;
            huh.enabled = !huh.enabled;
        }
        if(FindObjectOfType<SwarmAction>() != null)
        {
            FindObjectOfType<SwarmAction>().enabled = !FindObjectOfType<SwarmAction>().enabled;
        }
        if(FindObjectOfType<MimicAction>() != null)
        {
            FindObjectOfType<MimicAction>().enabled = !FindObjectOfType<MimicAction>().enabled;
        }
    }
}
