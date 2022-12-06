using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public bool mustPatrol;
    public float walkSpeed;
    public Rigidbody2D rb;
    private bool mustFlip;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public Collider2D bodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }

    }
    void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheck.position,0.1f,groundLayer);
        }

    }
    void Patrol()
    {
        if (mustFlip || bodyCollider.IsTouchingLayers(wallLayer)) {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);

    }
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
