using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int IdPlayer;
    public Sprite[] Spr_Player;
    public SpriteRenderer Character;
    public Rigidbody2D rb;
    public Collider2D Trigger;

    public float speed;
    public float jumpForce;

    public Animator anim;

    public Transform groundPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    public bool CanMove, CanJump;
    // Start is called before the first frame update
    void Start()
    {
        Character.sprite = Spr_Player[IdPlayer];
    }

    // Update is called once per frame
    void Update()
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

        if( x != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
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
}
