using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform player;
    public Transform shootPos;
   
    public float range;
    public GameObject bullet;
    private float distToPlayer;
    public Enemy enemy;
    bool isFacingRight = true;
    public PlayerHealth playerhealth;
    private Animator anim;
    public float fireRate = 0.25f;
    float nextFire;
    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer <= range)
        {
            if ((player.position.x > transform.position.x && !isFacingRight)
                || (player.position.x < transform.position.x && isFacingRight))
            {
                enemy.Flip();
                isFacingRight = !isFacingRight;
            }
            if (playerhealth.currentHealth != 0)
            {
                Shoot();
            }

        }
        else {
            anim.Play("Idle");
        }
    }
    void Shoot()
    {
        
        if (Time.time > nextFire) {

            anim.Play("shoot");
            source.PlayOneShot(clip);
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shootPos.position, shootPos.rotation);
            anim.Play("Idle");
        }
        
        
        
        
    }
}
