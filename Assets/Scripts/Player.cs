using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public ParticleSystem walk;

    public Animator anim;

    public Transform groundPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    public bool CanMove, CanJump;

    public int NumberLife, LifeMax;

    public Image Bar;
    public GameObject BarObject;
    public float Pv, PvMAx;

    public int Score;
    

    // Start is called before the first frame update
    void Start()
    {
        if(IdPlayer == 0)
        {
            BarObject = GameObject.Find("BlueHealth");
        }
        if (IdPlayer == 1)
        {
            BarObject = GameObject.Find("GreenHealth");
        }
        if (IdPlayer == 2)
        {
            BarObject = GameObject.Find("RedHealth");
        }
        if (IdPlayer == 3)
        {
            BarObject = GameObject.Find("YellowHealth");
        }

        Bar = BarObject.GetComponent<Image>();
        Pv = PvMAx;
        CollisionBullet = null;
        Pv = PvMAx;
        IdBulletPlayer = -1;
        walk.Stop();
        Debug.Log("FX_Test");
    }

    // Update is called once per frame
    private void Update()
    {
        Bar.fillAmount = Pv / PvMAx;
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
            walk.Play();
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
