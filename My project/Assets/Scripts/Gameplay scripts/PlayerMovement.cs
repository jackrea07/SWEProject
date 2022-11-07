using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

     public float moveSpeed = 3f;
     public float jumpSpeed = 5f;
    BoxCollider2D boxColliderPlayer;
    int layerMaskGround;
    float heightTestPlayer;

    float keyHorizontal;
    bool keyJump;

    // Start is called before the first frame update
    void Start()
    {
        boxColliderPlayer = GetComponent<BoxCollider2D>();

        heightTestPlayer = boxColliderPlayer.bounds.extents.y + 0.05f;

        layerMaskGround = LayerMask.GetMask("Ground");
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        keyHorizontal = Input.GetAxisRaw("Horizontal");
        keyJump = Input.GetKeyDown(KeyCode.W);
        rb2d.velocity = new Vector2(keyHorizontal * moveSpeed, rb2d.velocity.y);
        if (keyJump && IsGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
    }
    private bool IsGrounded()
    {
        // Note that we only check for colliders on the Ground layer (we don't want to hit ourself). 
        RaycastHit2D hit = Physics2D.Raycast(boxColliderPlayer.bounds.center, Vector2.down, heightTestPlayer, layerMaskGround);
        bool isGrounded = hit.collider != null;
        // It is soo easy to make misstakes so do a lot of Debug.DrawRay calls when working with colliders...
        Debug.DrawRay(boxColliderPlayer.bounds.center, Vector2.down * heightTestPlayer, isGrounded ? Color.green : Color.red, 0.5f);
        return isGrounded;
    }
}
