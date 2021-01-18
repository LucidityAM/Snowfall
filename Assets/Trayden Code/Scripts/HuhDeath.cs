using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HuhDeath : MonoBehaviour
{
    private GameObject bush;

    void Start() 
    {
        bush = GameObject.FindGameObjectWithTag("Bush");
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player") && bush.GetComponent<BushAction>().isHidden == false)
        {
            SceneManager.LoadScene("Forest");
        }
    }
}