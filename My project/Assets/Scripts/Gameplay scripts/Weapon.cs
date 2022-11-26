using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int currentAmmo = 20;
    public int maxAmmo = 20;
    bool keyFire;
    public Transform firePoint;
    public GameObject bullet;
    private Animator anim;
    float shootTimeLength;
    float shootTime;
    float releasetime;
    bool keyRelease;
    public PlayerHealth playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        shootTime = 0;
        releasetime = 0;
        playerhealth = GetComponent<PlayerHealth>();
        currentAmmo = maxAmmo;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        keyFire = Input.GetKeyDown(KeyCode.Space);
        if (keyFire && currentAmmo != 0 && keyRelease && !playerhealth.disabled) {
            keyRelease = false;
            anim.SetBool("isShooting", true);
            shootTime = Time.time;
            Invoke("Shoot", 0.1f);
            currentAmmo--;

        }
        if (!keyFire && currentAmmo != 0 && !keyRelease)
        {
            releasetime = Time.time - shootTime;
            keyRelease = true;
        }
        if (anim.GetBool("isShooting") == true) {
            shootTimeLength = Time.time - shootTime;
            if (shootTimeLength >= 0.25f || releasetime >= 0.15f)
            {
                anim.SetBool("isShooting", false);
            }
        }
    }
    void Shoot() {
        Instantiate(bullet,firePoint.position, firePoint.rotation);
    }
}
