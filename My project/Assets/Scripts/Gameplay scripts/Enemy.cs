using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer sprite;
    public int health = 3;

    public GameObject deathEffect;
    public IEnumerator red() { 
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            StartCoroutine(red());
        }
    }


        public void takeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            GameObject clone = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(clone, 0.4f);
        }
    }

}




