using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float moveSpeed;
    public float jumpSpeed;
    public bool isGround = false;
    float jumpCount;
    
    
    Animator animator;
    private Rigidbody rigid;
    private SpriteRenderer ren;
    private Collider col;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        ren = GetComponentInChildren<SpriteRenderer>();
        animator = gameObject.GetComponentInChildren<Animator>();
        col = GetComponentInChildren<Collider>();
        jumpCount = 1;
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Jump()
    {
        if (isGround)
        {
            jumpCount = 1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (jumpCount == 1)
                {
                    isGround = false;
                    rigid.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                    animator.SetTrigger("doJump");
                    animator.SetBool("isJump", true);
                    jumpCount = 0;
                }
            }
        }
    }
    
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("isWalk", false);
        }
        else if (x < 0)
        {
            moveVelocity = Vector3.left;
            ren.flipX = true;
            animator.SetBool("isWalk", true);
        }
        else if (x > 0)
        {
            moveVelocity = Vector3.right;
            ren.flipX = false;
            animator.SetBool("isWalk", true);
        }

        moveVelocity = new Vector3(x, 0, y) * moveSpeed * Time.deltaTime;
        this.transform.position += moveVelocity;
    }



    private void OnCollisionEnter(Collision floor)
    {

        if (floor.gameObject.tag.Equals("floor"))
        {
            isGround = true;
            jumpCount = 1;
        }

    }

    private void OnTriggerEnter(Collider floor)
    {
        Debug.Log("floor");
        if (floor.gameObject.layer == 7)
        {
            animator.SetBool("isJump", false);
        }
    }

}
