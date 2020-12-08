using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseBG;
    //public GameObject blur;

    private Animator pauseBGAnim;
    //private Animator blurAnim;


    #region Things that need to be turned off
    public PlayerMovement playerMovement;
    #endregion

    private bool paused;

    void Awake()
    {
        paused = false;

        pauseBG.SetActive(false);
        //blur.SetActive(false);

        #region Animators
        pauseBGAnim = pauseBG.GetComponent<Animator>();
        //blurAnim = blur.GetComponent<Animator>();
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
            StartCoroutine("OpenMenu");
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            StartCoroutine("CloseMenu");
        }
    }

    public IEnumerator OpenMenu()
    {
        paused = true;
        ToggleScripts();
        //blur.SetActive(true);
        //blurAnim.SetTrigger("IsOpen");
        yield return new WaitForSeconds(0.1f);
        pauseBG.SetActive(true);
        pauseBGAnim.SetBool("IsOpen", true);
    }

    public IEnumerator CloseMenu()
    {
        paused = false;
        ToggleScripts();
        pauseBGAnim.SetBool("IsOpen", false);
        yield return new WaitForSeconds(0.4f);
        pauseBG.SetActive(false);
        //blurAnim.SetTrigger("IsOpen");
        yield return new WaitForSeconds(0.3f);
    }

    public void ToggleScripts()
    {
        playerMovement.enabled = !playerMovement.isActiveAndEnabled;
    }
}
