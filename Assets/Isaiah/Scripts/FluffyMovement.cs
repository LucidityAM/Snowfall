using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FluffyMovement : MonoBehaviour
{
    public GameObject Character; // Target Object to follow
    Animator anim;

    public float speed; // Speed
    public float followDistance; //Distance to follow

    private Vector2 directionOfCharacter;
    private Vector2 run;

    public Transform runAway;

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
        else if(DialogueConditions.dogTrigger == true)
        {
            anim.SetBool("isMoving", true);

            run = runAway.position - gameObject.transform.position;
            run = run.normalized;    // Get Direction to Move Towards

            transform.Translate(run * speed, Space.World);
        }
    }
}

