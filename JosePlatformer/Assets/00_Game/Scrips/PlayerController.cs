using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 8f;
    [SerializeField] SpriteRenderer mySprite;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D myCapsuleCollider;
    [SerializeField] Animator myAnimator;
    [SerializeField] PlayerHealth myHealth;
    
    bool isGrounded;
    public bool isFlipped;



    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myHealth = GetComponent<PlayerHealth>();
      
    }

    void Update()
    {
        if (myHealth.death) return;
        Run();
        FlipSprite();
        CheckGrounded();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Run()
    {
        if (myHealth.death) return;
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            mySprite.transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);

            if (mySprite.transform.localScale.x < 0)
            {
                isFlipped = true;
            }

            else
            { isFlipped = false; }
        }

    }

    void OnJump(InputValue value)
    {
        if (myHealth.death) return;
        if (value.isPressed && isGrounded)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);

            myAnimator.SetBool("isJumping", true);

            FindObjectOfType<AudioManager>().Play("Jump");
        }
    }

    void CheckGrounded()
    {
        if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isGrounded = false;
        }
        else
        {
            if (!isGrounded)
            {
                myAnimator.SetBool("isJumping", false);
            }
            isGrounded = true;

        }
    }

    

}
