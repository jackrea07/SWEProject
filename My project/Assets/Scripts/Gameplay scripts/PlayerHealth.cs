using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }
    public void heal(int amount) {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
           
        }
    }

}
