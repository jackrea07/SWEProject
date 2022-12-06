using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHp : MonoBehaviour
{

    public SpriteRenderer sprite;
    public int health = 30;
    bool isInvincible;
    private Transform originalParent;
    public GameObject deathEffect;
    public PlayerHealth playerhealth;
    public IEnumerator red()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
    void Start()
    {
        Physics2D.IgnoreLayerCollision(11, 11, true);
    }
    void Update() {
        if (playerhealth.currentHealth == 0) {
            health = 30;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            StartCoroutine(red());
        }
    }


    public void takeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;

            if (health <= 0)
            {
                GameObject clone = Instantiate(deathEffect, transform.position, Quaternion.identity);

                Destroy(gameObject);
                Destroy(clone, 0.4f);
            }
        }
    }
    public void Flip()
    {
        transform.Rotate(0, 180f, 0);
    }


    public void Invincible(bool invincibility)
    {
        isInvincible = invincibility;
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




