using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.AI;

public class EnemyEngine : MonoBehaviour
{
    public AudioSource gunshot;
    public AudioSource footsteps;

    Transform player;
    public int moveSpeed;
    Animator animator;

    int shootRange;
    public LayerMask playerLayer;
    bool playerIsInRange;

    public int health;

    public GameObject bullet;
    float shootingTime;
    public Transform bulletOut;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        moveSpeed = 20;
        shootRange = 50;

        health = 100;

        shootingTime = 3;
    }


    void Update()
    {
        transform.LookAt(player);
        playerIsInRange = Physics.CheckSphere(transform.position, shootRange, playerLayer);

        shootingTime -= Time.deltaTime;

        if (!playerIsInRange)
        {
            footsteps.Play();
            animator.SetBool("isRunning", true);
            animator.SetBool("isShooting", false);
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (playerIsInRange)
        {
            footsteps.Pause();
            animator.SetBool("isShooting", true);
            animator.SetBool("isRunning", false);

            if (shootingTime <= 0)
            {
                
                Instantiate(bullet, bulletOut.position, Quaternion.identity);
                gunshot.Play();
                shootingTime = 3;
            }
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    void Die()
    {
        Destroy(gameObject);
        PlayerEngine.killedCount++;
    }
}
