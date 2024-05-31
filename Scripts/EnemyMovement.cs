using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    [SerializeField] Transform floorController;

    [SerializeField] GameObject player;

    [SerializeField] private bool movingRight;

    [SerializeField] private float distance;

    private Animator animator;

    private int damage = 20;

    private PlayerHealth health;

    private PlayerMovement movement;
        

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = player.GetComponent<PlayerHealth>();
        movement = player.GetComponent<PlayerMovement>();

    }
    

    
    // Update is called once per frame
    void Update()
    {
       // animator.SetBool(isMoving, true);
        rb.velocity = new Vector2(speed, rb.velocity.y);
        RaycastHit2D floor = Physics2D.Raycast(floorController.position, Vector2.down, distance);

        if(floor == false)
        {
            Turn();
        }
    }

    private void Turn()
    {
        movingRight = !movingRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speed *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Character") && !movement.isDashing)
        {
            health.TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(floorController.transform.position, floorController.transform.position + Vector3.down * distance);
    }
}
