using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float rememberGroundedFor;
    float lastTimeGrounded;

    public string currentScene;

    //Components
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentScene = SceneManager.GetActiveScene().ToString();
    }

    void Update()
    {
        

        Move();

        if(currentScene == "chase")
        {
            Jump();
            BetterJump();
        }
        
        CheckIfGrounded();

        anim.SetFloat("walkSpeed", Mathf.Abs(rb.velocity.x));
    }


    void Move()
    {
        if (isGrounded)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float moveBy = x * speed;
            rb.velocity = new Vector2(moveBy, rb.velocity.y);

            if (rb.velocity.x > 0)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0,180,0);
            }
            else if (rb.velocity.x < 0)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            //else if (rb.velocity.x == 0)
            //{
            //    this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            //}

            if (Mathf.Abs(rb.velocity.x) != 0 && isGrounded)
            {
                anim.speed = Mathf.Abs(rb.velocity.x) * .32f;
            }
            else if (isGrounded == false)
            {
                anim.speed = 0.6f;
            }//Scales animation speed with the walk speed;

        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            anim.SetBool("inJump", false);
        }
        else
        {
            anim.SetBool("inJump", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
 
    }//Checks if the player is grounded or if they were grounded in the last couple miliseconds and then jumps

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }


}
