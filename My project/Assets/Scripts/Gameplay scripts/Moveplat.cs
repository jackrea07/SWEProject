using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplat : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float distance = 0.05f;

    private Transform target;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target.position,speed *Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < distance) {
            target = next();
        }
    }
    private Transform next() {
        index++;
        if (index >= waypoints.Length) {
            index = 0;
        }
        return waypoints[index];
    }
    private void OnCollisionEnter2D(Collision2D other) {
        var playerMovement = other.collider.GetComponent<PlayerMovement>();
        if (playerMovement != null) {
            playerMovement.setParent(transform);

        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        var playerMovement = other.collider.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.resetParent();

        }
    }
}
