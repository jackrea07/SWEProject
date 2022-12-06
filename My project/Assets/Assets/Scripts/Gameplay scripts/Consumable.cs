using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Weapon ammo;
    public int ammoRestore = 10;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player" && playerHealth.currentHealth !=0)
        {
            if (playerHealth.currentHealth < playerHealth.maxHealth && gameObject.tag == "Health") {
                Destroy(gameObject);
            }
            if (ammo.currentAmmo < ammo.maxAmmo && gameObject.tag == "Ammo" && playerHealth.currentHealth != 0) {
                ammo.currentAmmo += ammoRestore;
                if (ammo.currentAmmo > ammo.maxAmmo) {
                    ammo.currentAmmo = ammo.maxAmmo;
                }
                Destroy(gameObject);
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
