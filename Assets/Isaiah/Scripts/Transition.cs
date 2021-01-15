using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject transition;
    public PlayerMovement playerMovement;
    public Rigidbody2D Player;
    public Animator anim;

    private float wait;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            StartCoroutine(Stop());
        }
    }

    public void Update()
    {
        wait = anim.GetFloat("walkSpeed");
    }

    public IEnumerator Stop()
    {
        Debug.Log(wait);

        playerMovement.enabled = false;
        Player.velocity = new Vector2(0f, 0f);
        Player.bodyType = RigidbodyType2D.Static;

        while (wait != 0)
        {
            anim.SetFloat("walkSpeed", 0);
            yield return null;
        }

        transition.SetActive(true);
        
        anim.enabled = false;
    }
}
