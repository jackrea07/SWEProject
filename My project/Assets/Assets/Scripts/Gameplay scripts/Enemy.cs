using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public SpriteRenderer sprite;
    public int health = 3;
    bool isInvincible;
    private Transform originalParent;
    public GameObject deathEffect;
    public IEnumerator red() { 
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
    void Start() {
        Physics2D.IgnoreLayerCollision(11, 11, true);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            StartCoroutine(red());
        }
    }


        public void takeDamage(int damage) {
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




