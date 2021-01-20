using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GyerjhtDeath : MonoBehaviour
{
    public Animator gyerjhtAnim;
     private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DeadTransition());
        }
    }
    public IEnumerator DeadTransition()
    {
        gameObject.GetComponent<GyerjhtOtherAction>().enabled = false;
        gyerjhtAnim.SetBool("isStunned", true);
        Death.isDead = true;
        yield return new WaitForSeconds(1f);
        Death.isDead = false;

        SceneManager.LoadScene("Forest");
    }
}
