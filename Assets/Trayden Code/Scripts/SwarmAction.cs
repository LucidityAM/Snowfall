﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwarmAction : MonoBehaviour
{
    private GameObject bush;
    private GameObject player;
    private GameObject keyItemActionController;
    private GameObject huh;
    private Vector2 origPos;
    private Vector2 velocity = Vector2.zero;

    void Start() 
    {
        origPos = GameObject.Find("Beehive").GetComponent<BeehiveOtherAction>().origPos;
        bush = GameObject.FindGameObjectWithTag("Bush");
        player = GameObject.FindGameObjectWithTag("Player");
        keyItemActionController = GameObject.FindGameObjectWithTag("Action Controller");
        huh = GameObject.Find("Huh");
    }
    void Update()
    {
        if(bush.GetComponent<BushAction>().isHidden == false)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, 5f * Time.deltaTime);
        }
        else if(bush.GetComponent<BushAction>().isHidden == true && 
        keyItemActionController.GetComponent<KeyItemActionList>().isInPosition == true)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, huh.transform.position, 5f * Time.deltaTime);
        }
        else if (bush.GetComponent<BushAction>().isHidden == true)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, origPos, 5f * Time.deltaTime);
        }
        if(gameObject.transform.position.y < 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DeadTransition());
        }
        if(collision.gameObject.name == "Huh")
        {
            huh.SetActive(false);
            Destroy(gameObject);
        }
    }

    public IEnumerator DeadTransition()
    {

        Death.isDead = true;

        yield return new WaitForSeconds(1f);
        Death.isDead = false;

        SceneManager.LoadScene("Forest");
    }

}
