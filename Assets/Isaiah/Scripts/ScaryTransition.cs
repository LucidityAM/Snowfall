using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class ScaryTransition : MonoBehaviour
{
    public Animator chromatic;

    public GameObject chromaticGO;
    public GameObject staticGO;
    public GameObject DissolveGO;

    public Material dissolveMat;

    float fade = 1f;

    bool isDissolving;

    public PlayerMovement playerMovement;
    public Rigidbody2D Player;
    public Animator playerAnim;
    public GameObject transitionBar;

    void Start()
    {
        fade = 1f;
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {

        while (chromatic.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            yield return null;

        staticGO.SetActive(true);

        yield return new WaitForSeconds(4.5f);

        DissolveGO.SetActive(true);

        yield return new WaitForSeconds(.2f);

        staticGO.SetActive(false);

        yield return new WaitForSeconds(2f);

        chromaticGO.GetComponent<SpriteRenderer>().enabled = false;

        Dissolve();
       
    }

    public void Dissolve()
    {
        isDissolving = true;
    }

    void Update()
    {

        if (isDissolving)
        {
            fade -= Time.deltaTime *.4f;

            if (fade <= 0f)
            {
                transitionBar.SetActive(false);

                playerAnim.enabled = true;
                Player.bodyType = RigidbodyType2D.Dynamic;
                playerMovement.enabled = true;

                fade = 0f;
                isDissolving = false;
                DissolveGO.SetActive(false);
            }

            dissolveMat.SetFloat("_Fade", fade); 
        }
    }
}
    

