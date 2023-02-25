using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    // values for player movement

    private Rigidbody2D rb2D;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    // animator allows animations
    public Animator animator;

    //bool allowing for direction change
    [HideInInspector]
    public bool facingRight;


    // makes sure the player is facing right at the start and assigns values for move speed/ bool for jumping
    //bool for jumping makes sure the player cant fly by holding w or up arrow
    void Start()
    {

        facingRight = true;
        moveSpeed = 1f;
        jumpForce = 20f;
        isJumping = false;
        rb2D = gameObject.GetComponent<Rigidbody2D>();

    }

    // collects information on player movement
    void Update()
    {
        
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("speed", Mathf.Abs(moveHorizontal));
        

    }

    //fixed update that allows player to move/jump
    // also allows the player to change character direction
    void FixedUpdate()
    {

        if (moveHorizontal > 0.1f)
        {
            facingRight = true;
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f),ForceMode2D.Impulse);
            
        }

        if (moveHorizontal < -0.1f)
        {
            facingRight = false;
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
           
        }

        if (!isJumping && moveVertical > 0.1f)
        {

            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }

        if (facingRight)
        {
            transform.localScale = new Vector2(2, 2);
        } else if (!facingRight)
        {
            transform.localScale = new Vector2(-2, 2);
        }


    }
    // makes sure the player can only jump when on the ground
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "CollidePlatform")
        {
            
            animator.SetBool("jumping", false);
            isJumping = false;
            

        }

    }

    //makes sure the player can jump when on the ground
    void OnTriggerExit2D(Collider2D collision)
    {



        if (collision.gameObject.tag == "CollidePlatform")
        {
            animator.SetBool("jumping", true);
            isJumping = true;
           

        }

    }


}
