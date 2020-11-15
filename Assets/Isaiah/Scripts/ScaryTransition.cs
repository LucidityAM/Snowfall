using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class ScaryTransition : MonoBehaviour
{
    public Animator chromatic;
    public Animator distortion;


    public GameObject chromaticGO;
    public GameObject distortionGO;
    public GameObject staticGO;

    public RenderPipelineAsset URP;
    public RenderPipelineAsset twoD;

    void Start()
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        GraphicsSettings.renderPipelineAsset = twoD;

        while (chromatic.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            yield return null;

        GraphicsSettings.renderPipelineAsset = URP;

        distortionGO.SetActive(true);

        distortion.SetTrigger("Distortion");

        yield return new WaitForSeconds(3f);

        staticGO.SetActive(true);
        chromaticGO.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(3f);

        distortionGO.SetActive(false);
        staticGO.SetActive(false);
        chromaticGO.GetComponent<SpriteRenderer>().enabled = true;

        GraphicsSettings.renderPipelineAsset = twoD;

    }
}
    

