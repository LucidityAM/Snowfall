using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreddyHuhDeath : MonoBehaviour
{
    public GameObject bush;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.name == "Huh" && bush.GetComponent<BushAction>().isHidden == false)
        {
            StartCoroutine(DeadTransition());
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
