using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEngine : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] CharacterController cc;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform weapon;
    [SerializeField] Camera rayCam;
    [SerializeField] Text healthTXT;
    [SerializeField] Text killedTXT;
    [SerializeField] ParticleSystem flash;
    float mouseY;
    float mouseX;
    float cameraX;
    float moveZ;
    float moveX;
    int lookSpeed;
    int moveSpeed;
    float radius;
    bool isGrounded;
    int rayRange;
    public static int health;
    public static int killedCount;
    
    void Start()
    {
        lookSpeed = 80;
        moveSpeed = 35;
        radius = Mathf.Infinity;
        rayRange = 100;
        health = 100;
        killedCount = 0;

        transform.position = new Vector3(450, 6.33f, 450);
    }


    void Update()
    {
        weapon.localScale = new Vector3(1.5f, 1, 1.5f);

        Rotate();
        Movement();

        healthTXT.text = health.ToString();
        killedTXT.text = killedCount.ToString();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Rotate()
    {
        mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

        transform.Rotate(0, mouseX, 0);
        cam.Rotate(-mouseY, 0, 0);

        cameraX -= mouseY;
        cameraX = Mathf.Clamp(cameraX, -90, 90);

        cam.localRotation = Quaternion.Euler(cameraX, 0, 0);
    }
    void Movement()
    {
        moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        cc.Move(transform.forward * moveZ + transform.right * moveX);
    }

    public void Shoot()
    {
        flash.Play();

        RaycastHit hit;

        if (Physics.Raycast(rayCam.transform.position, rayCam.transform.forward, out hit, rayRange))
        {         
            EnemyEngine enemyEngine = hit.transform.GetComponent<EnemyEngine>();

            if (enemyEngine != null)
            {
                enemyEngine.TakeDamage(40);
            }
        } 
    }

    void highlightClosestEnemy()
    {
        if (Physics.CheckSphere(transform.position, radius))
        {

        }
    }
}
