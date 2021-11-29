using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool Shoot;
    public int IdPlayer;
    public Sprite[] Spr_Player;
    public Rigidbody2D rb;
    public Collider2D Trigger;

    public GameObject CollisionBullet;
    public int IdBulletPlayer; 

    public float speed;
    public float jumpForce;

    public Animator anim;

    public Transform groundPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    public bool CanMove, CanJump;

    public int NumberLife, LifeMax;
    public int Pv, PvMAx;

    // Start is called before the first frame update
    void Start()
    {
        CollisionBullet = null;
        Pv = PvMAx;
        IdBulletPlayer = -1;
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        if (CanMove)        
            Move();               
        if(CanJump && CanMove)
            Jump();

        if (isGrounded == true)
        {
           
            anim.SetBool("isJumping", false);
        }
        else
        {           
            anim.SetBool("isJumping", true);
        }

        
        
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        Vector3 rotate = transform.localScale;

        

        if (x > 0)
        {
            rotate.y = 180;
            transform.localEulerAngles = rotate;
        }
        
        if (x < 0)
        {
            rotate.y = 0;
            transform.localEulerAngles = rotate;

        }

     
        if( x != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("takeOf");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

       CanJump = true; 
       if(collision.CompareTag("Teleporter"))
       {
            CanJump = false;
       }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CanJump = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CanJump = true;
        if (collision.CompareTag("Teleporter"))
        {
            CanJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void OnClickPlusLife()
    {
        if (LifeMax != 99)
        {
            LifeMax++;
        }
    }
    void OnClickMoinsLife()
    {
        if (LifeMax != 1)
        {
            LifeMax--;
        }
    }

}
