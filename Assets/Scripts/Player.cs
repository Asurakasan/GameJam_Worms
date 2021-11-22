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

    public bool CanMove, CanJump;
    // Start is called before the first frame update
    void Start()
    {
        Character.sprite = Spr_Player[IdPlayer];
        
    }

    // Update is called once per frame
    void Update()
    {

        if (CanMove)
            Move();
        if(CanJump && CanMove)
            Jump();
        

    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       CanJump = true;  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CanJump = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CanJump = true;
    }
}
