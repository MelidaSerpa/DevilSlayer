using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    //Player body, speed, jumpForce and spriteRenderer attachment/management
    [SerializeField]
    private Rigidbody2D mybody;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private SpriteRenderer sr;
    private float movementX;

    [SerializeField]
    private float jumpForce;


    //



    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        //Action functions 
        isJump();
        
        isRun();     

    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        jumpAnim();
        isMove();
        isRunAnim();

        if (movementX > 0 && movementSpeed > 0)
        {
            sr.flipX = false;
        }
        else if (movementX < 0 && movementSpeed > 0)
        {
            sr.flipX = true;
        }
    }


    //Movement input
    void isMove()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX,0,0) * movementSpeed * Time.deltaTime;

        if (movementX < 0 && movementSpeed == 3)
        {
            anim.SetBool("Walk", true);
        }
        else if (movementX > 0 && movementSpeed == 3)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    //Jump input
    void isJump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(mybody.velocity.y) < 0.001f)
        {
            mybody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void jumpAnim()
    {
        if (mybody.velocity.y == 0)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Land", false);
        }
        else if (mybody.velocity.y > 0)
        {
            anim.SetBool("Jump", true);
            movementSpeed = 8;
        }
        else if (mybody.velocity.y < 0)
        {
            anim.SetBool("Land", true);
            anim.SetBool("Jump", false);
            movementSpeed = 8;
        }
    }

    //Run input
    void isRun()
    {
        if (Input.GetKey(KeyCode.LeftShift) && mybody.velocity.y == 0)
        {
            movementSpeed = 12;        
        }
        else
        {
            movementSpeed = 3;          
        }
    }


    void isRunAnim()
    {
        if (movementSpeed == 12 && Mathf.Abs(movementX) > 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
}
