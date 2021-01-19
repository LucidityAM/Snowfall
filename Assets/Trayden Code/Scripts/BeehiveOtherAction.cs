using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeehiveOtherAction : MonoBehaviour
{
    public GameObject beeSwarm;
    public GameObject beeLight;
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
        else if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Forest");
        }
    }
}
