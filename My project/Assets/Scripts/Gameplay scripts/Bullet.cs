using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEfect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag != "Player" && !hitInfo.isTrigger) {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.takeDamage(damage);
           
            }
            GameObject clone = Instantiate(impactEfect,transform.position,transform.rotation);
            
            Destroy(gameObject);
            
            Destroy(clone, 0.4f);
        }
        
    }
}
