using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MimicAction : MonoBehaviour
{
    private GameObject player;
    private Vector2 finalPos;
    private bool isLoaded = false;
    public int beehiveHitCount = 0;
    public float newSpeed = .10f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("HoldOn");
    }

    void Update()
    {
        if(isLoaded == true)
        {
            finalPos = new Vector2(player.transform.position.x, gameObject.transform.position.y);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, finalPos, newSpeed);
            if(beehiveHitCount >= 3)
            {
                SceneManager.LoadScene("Credits");
            }
        }
    }

    IEnumerator HoldOn()
    {
        yield return new WaitForSeconds(2.0f);
        isLoaded = true;
    }
}