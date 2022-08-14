using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEngine : MonoBehaviour
{
    Transform player;
    Rigidbody rb;
    int speed;
    Vector3 moveDir;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        moveDir = (player.transform.position - transform.position);
        speed = 500;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3 (moveDir.x, moveDir.y, moveDir.z) * speed * Time.deltaTime;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {              
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerEngine.health -= 20;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
}
