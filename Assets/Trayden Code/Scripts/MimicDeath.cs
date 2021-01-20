using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MimicDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DeadTransition());
        }
        else if(collision.gameObject.CompareTag("Key Item"))
        {
            gameObject.GetComponent<MimicAction>().enabled = false;
            StartCoroutine("BeehiveHit");
        }
    }
    public IEnumerator DeadTransition()
    {
        gameObject.GetComponent<MimicAction>().enabled = false;
        Death.isDead = true;
        yield return new WaitForSeconds(1f);
        Death.isDead = false;

        SceneManager.LoadScene("Chase");
    }

    IEnumerator BeehiveHit()
    {
        gameObject.GetComponent<MimicAction>().newSpeed = gameObject.GetComponent<MimicAction>().newSpeed += .05f;
        yield return new WaitForSeconds(2.0f);
        gameObject.GetComponent<MimicAction>().enabled = true;
    }
}
