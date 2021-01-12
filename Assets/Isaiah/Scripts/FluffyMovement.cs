using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluffyMovement : MonoBehaviour
{
    public GameObject player;
    private Vector2 velocity = Vector2.zero;

    bool isFlipped;

    void Update()
    {
        if (gameObject.transform.position.x - player.transform.position.x < -2.3f && isFlipped == false)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

            Vector2 playerPosAdj = new Vector2(player.transform.position.x - 2.5f, player.transform.position.y + 1.3f);

            gameObject.transform.position = Vector2.SmoothDamp(gameObject.transform.position, playerPosAdj, ref velocity, .15f, Mathf.Infinity, Time.deltaTime);    
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

            Vector2 playerPosAdj = new Vector2(player.transform.position.x + 2.5f, player.transform.position.y + 1.3f);

            gameObject.transform.position = Vector2.SmoothDamp(gameObject.transform.position, playerPosAdj, ref velocity, .15f, Mathf.Infinity, Time.deltaTime);

            StartCoroutine(Wait());
        }


        if(gameObject.transform.position.x - player.transform.position.x < 2.45f && isFlipped)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

            Vector2 playerPosAdj = new Vector2(player.transform.position.x + 2.5f, player.transform.position.y + 1.3f);

            gameObject.transform.position = Vector2.SmoothDamp(gameObject.transform.position, playerPosAdj, ref velocity, .15f, Mathf.Infinity, Time.deltaTime);
        }

        Debug.Log(gameObject.transform.position.x - player.transform.position.x);

    }


    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);

        isFlipped = true;
    }
}
