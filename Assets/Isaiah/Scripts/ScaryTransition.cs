using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ScaryTransition : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        
    }

    IEnumerator StartAnimation()
    {
        while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            yield return null;

        anim.SetTrigger("Distortion");
    }
}
    

