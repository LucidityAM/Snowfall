using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballThrow : MonoBehaviour
{
    Vector2 worldPoint;
    RaycastHit2D hit;
    public GameObject snowballProjectile;
    public GameObject player;
    public GameObject keyItem;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 

            worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if(hit.collider.CompareTag("Key Item"))
            {
                keyItem = hit.collider.gameObject;
                Instantiate(snowballProjectile, new Vector3(player.transform.position.x + .75f, player.transform.position.y + 2f, 0), Quaternion.identity);
                gameObject.GetComponent<UnlockThrow>().isActive = false;
                gameObject.GetComponent<SnowballThrow>().enabled = false;
            }
            else if(hit.collider.CompareTag(null))
            {
                gameObject.GetComponent<UnlockThrow>().isActive = false;
                gameObject.GetComponent<SnowballThrow>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<UnlockThrow>().isActive = false;
                gameObject.GetComponent<SnowballThrow>().enabled = false;
            }
        }
    }
}
