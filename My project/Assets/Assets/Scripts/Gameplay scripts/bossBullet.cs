using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    public int damage = 1;
    public float speed = 20f;
    
    public Rigidbody2D rb;
    public GameObject impactEfect;
    public PlayerHealth playerhealth;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
        //StartCoroutine(CountDownTimer());

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag != "Enemy" && !hitInfo.isTrigger)
        {
            playerhealth = hitInfo.GetComponent<PlayerHealth>();
            if (playerhealth != null && playerhealth.currentHealth > 0 && !playerhealth.isInvincible)
            {
                playerhealth.takeDamage(damage);
                GameObject clone = Instantiate(impactEfect, transform.position, transform.rotation);

                Destroy(gameObject);

                Destroy(clone, 0.4f);
                if (playerhealth.currentHealth > 0)
                {
                    playerMovement.KBCounter = playerMovement.KBTotalTime;
                    if (hitInfo.transform.position.x <= transform.position.x)
                    {
                        playerMovement.knockedFromRight = true;
                    }
                    if (hitInfo.transform.position.x > transform.position.x)
                    {
                        playerMovement.knockedFromRight = false;
                    }
                }

            }

            

        }

    }
    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
