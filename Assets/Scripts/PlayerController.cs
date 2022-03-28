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
    ScoreCalculator scoreCalculator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        scoreCalculator = GameObject.Find("ScoreManager").GetComponent<ScoreCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreCalculator.IsGameOver == false)
        {
            animator.SetTrigger("Idle");
            if (Input.GetKeyDown(KeyCode.Space))     // TO Jump
            {
                animator.SetTrigger("IsJumping");
                rb.AddForce(Vector2.up * playerJumpForce);
            }
            if (Input.GetKeyDown(KeyCode.M))        // To Attack
            {
                animator.SetTrigger("IsAttacking");
            }
            if (Input.GetKeyDown(KeyCode.N))       //TO Slide
            {
                animator.SetTrigger("IsSliding");
            }
            inputX = Input.GetAxis("Horizontal");

            if (inputX > 0 || inputX < 0)           // Running Animation when moving
                animator.SetTrigger("IsRunning");
            if (inputX > 0)                        // FLipping the player based on direction
                render.flipX = false;
            else if (inputX < 0)
                render.flipX = true;
        }
        //Need to do running part
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX * playerSpeed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Gems")         // Score updation, when player collects gems
        {
            Destroy(collision.gameObject);
            scoreCalculator.Score();
        }
    }

}
