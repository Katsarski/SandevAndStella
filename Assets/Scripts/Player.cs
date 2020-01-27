using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance;

    private Animator anim;
    private Rigidbody2D myRigidbody;
    private static float horizontal;
    private bool facingRight;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float fallMultiplier = 2.5f;
    [SerializeField]
    private float lowJumpMultiplier = 2f;
    [SerializeField]
    [Range(1, 100)]
    private float jumpVelocity;

    #region GroundVars
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private float enemyHeadJumpMultiplier;
    #endregion

    void Awake()
    {
        instance = this;
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //We use fixed update so it runs the same on all platforms
    void FixedUpdate()
    {
        horizontal = SimpleInput.GetAxis("Horizontal");
        //Move(horizontal);

        #region Jumping
        //Check if we can jump
        if (SimpleInput.GetButton("Jump") && isGrounded == true)
        {
            //Jump
            myRigidbody.velocity += Vector2.up * System.Math.Abs(Physics2D.gravity.y) * Time.deltaTime * jumpVelocity;
            if (anim.GetBool("Jump") == false)
            {
                anim.SetBool("Jump", true);
            }
        }
        //Check if we are falling and player is still holding Jump
        if (myRigidbody.velocity.y < 0)
        {
            myRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //Check if we are falling and player has released Jump
        else if (myRigidbody.velocity.y > 0 && !SimpleInput.GetButton("Jump"))
        {
            myRigidbody.velocity += (Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
        }
        #endregion
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, ground);
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        Flip(horizontal);
        if (isGrounded == true)
        {

            Move(horizontal);
            anim.SetBool("Jump", false);
        }

    }

    private void Move(float horizontal)
    {

        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        if (myRigidbody.velocity.x == 0)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Idle", true);
        }
        else if (myRigidbody.velocity.x > 0 || myRigidbody.velocity.x < 0)
        {
            anim.SetBool("Run", true);
            Flip(horizontal);
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Platform")
        {
            //If we collide with a platform AND  we are above the platform set grounded to true so we can jump off the platform
            if (other.transform.position.y < gameObject.transform.position.y)
            {
                isGrounded = true;
            }
            //Otherwise we are still not grounded - to avoid a bug where we are catapulted to the air
            isGrounded = false;
        }
        //Check if we have collided with Enemy
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //If we are on higher ground than enemy kill him
            if (groundCheck.transform.position.y > other.gameObject.GetComponent<BoxCollider2D>().bounds.max.y - 0.2)
            {
                try
                {
                    other.gameObject.GetComponent<EnemyCommon>().Die();
                }
                catch (NullReferenceException e)
                {
                    Debug.Log("Tried getting EnemyCommon script from enemy but couldn't find it");
                    Debug.LogError(e.Message);
                }

                Destroy(other.gameObject);
                myRigidbody.velocity = Vector2.up * enemyHeadJumpMultiplier;
            }
            //Otherwise player gets damaged
            else
            {
                PlayerHealth.instance.Damage(1);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        //If we collide with a platform AND  we are above the platform set grounded to true so we can jump off the platform
        if (other.gameObject.tag == "Platform")
        {
            if (other.transform.position.y < gameObject.transform.position.y)
            {
                isGrounded = true;
            }
            //Otherwise we are still not grounded - to avoid a bug where we are catapulted to the air
            isGrounded = false;

        }
        //Check if we have collided with Trap
        if (other.gameObject.layer == LayerMask.NameToLayer("Traps"))
        {
            //Take all the hearts from the player
            PlayerHealth.instance.Damage(PlayerHealth.instance.maxHP);
            myRigidbody.velocity = Vector2.up * jumpVelocity;
            //anim.SetBool("Jump", false);
        }


    }
}
