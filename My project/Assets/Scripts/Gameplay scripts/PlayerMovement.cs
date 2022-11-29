using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    private SpriteRenderer _renderer;
    public bool isFacingRight = true;
    public float KBForce = 6f;
    public float KBCounter;
    public float KBTotalTime = 0.2f;
    public bool knockedFromRight;
    public float moveSpeed = 3f;
    public float jumpSpeed = 5f;
    private Animator anim;
    private Transform originalParent;
    BoxCollider2D boxColliderPlayer;
    int layerMaskGround;
    float heightTestPlayer;
    public PlayerHealth playerhealth;

    float keyHorizontal;
    bool keyLeft;
    bool keyRight;
    bool keyJump;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        boxColliderPlayer = GetComponent<BoxCollider2D>();

        heightTestPlayer = boxColliderPlayer.bounds.extents.y + 0.05f;
        playerhealth = GetComponent<PlayerHealth>();
        layerMaskGround = LayerMask.GetMask("Ground");
        rb2d = GetComponent<Rigidbody2D>();
        originalParent = transform.parent;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (KBCounter <= 0)
        {
            keyHorizontal = Input.GetAxisRaw("Horizontal");
            keyLeft = Input.GetKeyDown(KeyCode.A);
            keyRight = Input.GetKeyDown(KeyCode.D);
            keyJump = Input.GetKeyDown(KeyCode.W);

            if (keyLeft && !playerhealth.disabled)
            {
               
                rb2d.velocity = new Vector2(keyHorizontal * moveSpeed, rb2d.velocity.y);
                if (isFacingRight)
                {
                    transform.Rotate(0f, 180f, 0f);
                }

                isFacingRight = false;

            }
            if (keyRight && !playerhealth.disabled)
            {
                
                rb2d.velocity = new Vector2(keyHorizontal * moveSpeed, rb2d.velocity.y);
                if (!isFacingRight)
                {
                    transform.Rotate(0f, 180f, 0f);
                }
                isFacingRight = true;

            }
            if (playerhealth.currentHealth > 0)
            {
                rb2d.velocity = new Vector2(keyHorizontal * moveSpeed, rb2d.velocity.y);
            }
            if (keyJump && IsGrounded() && !playerhealth.disabled)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                
            }
            if (rb2d.velocity.y >= 0.1 || rb2d.velocity.y <= -0.1) {
                anim.SetBool("isJumping", true);
            }
            if (rb2d.velocity.y <= 0.1 && rb2d.velocity.y >= -0.1)
            {
                anim.SetBool("isJumping", false);
            }



        }
        else
        {
            if (knockedFromRight == true)
            {
                rb2d.velocity = new Vector2(-KBForce, KBForce);
            }
            if (knockedFromRight == false)
            {
                rb2d.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }
        anim.SetBool("isMoving", keyHorizontal != 0);


    }
    public bool IsGrounded()
    {

        RaycastHit2D hit = Physics2D.Raycast(boxColliderPlayer.bounds.center, Vector2.down, heightTestPlayer, layerMaskGround);
        bool isGrounded = hit.collider != null;

        // Debug.DrawRay(boxColliderPlayer.bounds.center, Vector2.down * heightTestPlayer, isGrounded ? Color.green : Color.red, 0.5f);
        return isGrounded;
    }
    public void setParent(Transform newParent)
    {
        originalParent = transform.parent;
        transform.parent = newParent;
    }
    public void resetParent()
    {
        transform.parent = originalParent;
    }
}
