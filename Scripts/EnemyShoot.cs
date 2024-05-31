using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
          public Transform shootController;

    
    public bool playerInRange = false;
    
    public float distanciaLinea;

    public float timeBetweenShoots;

    public float timeLastShoot;
        
    public GameObject enemyBullet;

    public float shootCooldown;


        private void Update()
        {

            if (playerInRange)
            {
                if (Time.time > timeBetweenShoots + timeLastShoot)
                {
                    timeLastShoot = Time.time;
                    Invoke(nameof(Shoot), shootCooldown);
                }
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Character"))
            {
            playerInRange = true;
            }
        }

        private void Shoot()
        {
            Instantiate(enemyBullet, shootController.position, shootController.rotation);
        }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(shootController.position, shootController.position + transform.right * distanciaLinea);
    }
}
