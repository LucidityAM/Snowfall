﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HuhDeath : MonoBehaviour
{
    private GameObject bush;
    private BoxCollider2D huhCollider;
    public GameObject huhAction;

    void Start() 
    {
        bush = GameObject.FindGameObjectWithTag("Bush");
        huhCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player") && bush.GetComponent<BushAction>().isHidden == false)
        {
            StartCoroutine(DeadTransition());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bush"))
        {
            huhCollider.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Bush"))
        {
            huhCollider.isTrigger = false;
        }
    }

    public IEnumerator DeadTransition()
    {
        huhAction.SetActive(false);
        Death.isDead = true;
        yield return new WaitForSeconds(1f);
        Death.isDead = false;

        SceneManager.LoadScene("Forest");
    }
}