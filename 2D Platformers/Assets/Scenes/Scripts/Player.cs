using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    

    private Rigidbody2D rb2D;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    public Animator animator;

    [HideInInspector]
    public bool facingRight;



    // Start is called before the first frame update
    void Start()
    {

        facingRight = true;
        moveSpeed = 1f;
        jumpForce = 20f;
        isJumping = false;
        rb2D = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("speed", Mathf.Abs(moveHorizontal));
        

    }

    
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
    
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "CollidePlatform")
        {
            
            animator.SetBool("jumping", false);
            isJumping = false;
            

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {



        if (collision.gameObject.tag == "CollidePlatform")
        {
            animator.SetBool("jumping", true);
            isJumping = true;
           

        }

    }


}
