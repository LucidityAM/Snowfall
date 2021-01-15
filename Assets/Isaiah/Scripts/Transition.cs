using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject transition;
    public PlayerMovement playerMovement;
    public Rigidbody2D Player;
    public Animator anim;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            transition.SetActive(true);
            playerMovement.enabled = false;
            Player.velocity = new Vector2(0f,0f);
        }
    }
}
