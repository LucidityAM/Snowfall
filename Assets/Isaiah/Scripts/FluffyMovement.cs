using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FluffyMovement : MonoBehaviour
{
    public GameObject Character; // Target Object to follow
    Animator anim;

    public float speed = 0.1F; // Speed
    public float followDistance; //Distance to follow

    private Vector2 directionOfCharacter;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        if(DialogueConditions.dogTrigger == false)
        {
            if (Vector2.Distance(Character.transform.position, gameObject.transform.position) >= followDistance)
            {
                if (Vector2.Distance(Character.transform.position, gameObject.transform.position) >= (followDistance + .1f))
                {
                    anim.SetBool("isMoving", true);
                }

                directionOfCharacter.x = Character.transform.position.x - transform.position.x;
                directionOfCharacter.y = (Character.transform.position.y + 1.5f) - transform.position.y;
                directionOfCharacter = directionOfCharacter.normalized;    // Get Direction to Move Towards
                transform.Translate(directionOfCharacter * speed, Space.World);
                transform.rotation = Character.transform.rotation;
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
        }
        else
        {
            anim.SetBool("isMoving", true);
            transform.Translate((directionOfCharacter * speed * 100f), Space.World);
        }
    }
}

