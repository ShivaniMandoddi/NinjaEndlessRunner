using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer render;
    public float playerJumpForce;
    public float playerSpeed;
    float inputX;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("Idle");
        if (Input.GetKeyDown(KeyCode.Space))     // TO Jump
        {
            animator.SetTrigger("IsJumping");
            rb.AddForce(Vector2.up * playerJumpForce);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("IsAttacking");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("IsSliding");
        }
        inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * playerSpeed, rb.velocity.y);
        if (inputX > 0 || inputX < 0)
            animator.SetTrigger("IsRunning");
        if (inputX > 0)
            render.flipX = false;
        else if (inputX < 0)
            render.flipX = true;
            
        //Need to do running part
    }
    
    
}
