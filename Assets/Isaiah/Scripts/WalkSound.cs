using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource audioSrc;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x != 0)
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else
        {
            audioSrc.Stop();
        }//Plays the sound of walking if the player is walking
    }
}
