using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject deathEffect;
    public int maxHealth = 3;
    public int currentHealth = 3;
    public int healthpack = 1;
    public float iFrameLength = 1f;
    public int numFlashes = 3;
    private SpriteRenderer sprite;
    public Animator animator;
    public Transform respawnPoint;
    private Animator anim;
    public Weapon wep;
    public bool disabled;
    public int numLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        disabled = false;
        sprite = GetComponent<SpriteRenderer>();
        wep = GetComponent<Weapon>();
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            numLives -= 1;
            StartCoroutine(die());
            
            

        }
        else {
            disabled = true;
            anim.Play("hit");
            StartCoroutine(invulnerability());
            StartCoroutine(wait1Sec());
        }
    }
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Health" && currentHealth >0)
        {
            if (currentHealth <maxHealth) {
                currentHealth += healthpack;
                Destroy(player);
            }

        }

    }

    private IEnumerator invulnerability() {
        Physics2D.IgnoreLayerCollision(10,11,true);
        for (int i = 0; i < numFlashes; i++)
        {
            sprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameLength / (numFlashes*2));
            sprite.color = Color.white;
            yield return new WaitForSeconds(iFrameLength / (numFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);

    }
    private IEnumerator die()
    {
        
        currentHealth = 0;
        GameObject clone = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(clone, 0.4f);
        sprite.enabled = false;
        disabled = true;
        if (numLives > 0)
        {
            yield return new WaitForSeconds(3);
            gameObject.transform.position = respawnPoint.transform.position;
            sprite.enabled = true;
            currentHealth = maxHealth;
            wep.currentAmmo = wep.maxAmmo;
            anim.Play("Idle");
            disabled = false;
            StartCoroutine(invulnerability());
        }
        else {
            Debug.Log("Game over");
            SceneManager.LoadScene("Game Over");
        }

    }
    private IEnumerator wait1Sec()
    {
        
        yield return new WaitForSeconds(1);
        anim.Play("Idle");
        disabled = false;

    }


}
