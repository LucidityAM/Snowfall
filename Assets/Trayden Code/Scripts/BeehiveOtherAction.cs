using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeehiveOtherAction : MonoBehaviour
{
    public GameObject beeSwarm;
    public GameObject beeLight;
    public GameObject Mimic;
    public Vector2 origPos;

    void Start() 
    {
        origPos = gameObject.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("floor"))
        {
            Instantiate(beeSwarm, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.25f), Quaternion.identity);
            beeLight.transform.position = new Vector2(100f, 100f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(collision.gameObject.CompareTag("floor2"))
        {
            beeLight.transform.position = new Vector2(100f, 100f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            beeLight.transform.position = new Vector2(100f, 100f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(DeadTransition());
        }
        else if(collision.gameObject.CompareTag("Mimic"))
        {
            beeLight.transform.position = new Vector2(100f, 100f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Mimic.GetComponent<MimicAction>().beehiveHitCount++;
        }
    }

    public IEnumerator DeadTransition()
    {

        Death.isDead = true;

        yield return new WaitForSeconds(1f);
        Death.isDead = false;
        if(SceneManager.GetActiveScene().name == "Chase")
        {
            SceneManager.LoadScene("Chase");
        }
        else
        {
            SceneManager.LoadScene("Forest");   
        }
    }
}
