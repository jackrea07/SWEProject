using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public int damage = 1;




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerHealth.currentHealth > 1)
            {
                playerMovement.KBCounter = playerMovement.KBTotalTime;
                if (collision.transform.position.x <= transform.position.x)
                {
                    playerMovement.knockedFromRight = true;
                }
                if (collision.transform.position.x > transform.position.x)
                {
                    playerMovement.knockedFromRight = false;
                }
            }
            playerHealth.takeDamage(damage);
           
        }
    }
}
  

    

