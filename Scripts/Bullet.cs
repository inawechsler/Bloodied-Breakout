using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.left);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerHealth health))
        {
            if (collision.TryGetComponent(out PlayerMovement player))
            {
                if (player.isDashing)
                {
                    Destroy(gameObject);
                }
                else
                {
                    health.TakeDamage(damage);
                    Destroy(gameObject);
                }
                // Pasar un vector nulo como posición


            }
        }

    }
}
