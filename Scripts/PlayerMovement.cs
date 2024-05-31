using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    public bool canMove = true;

    [Header("Movimiento")]
    private float HorizontalMov = 0f;
    [SerializeField] private float speedMov;
    [Range(0, 0.3f)][SerializeField] private float smoothMov;
    private Vector3 speed = Vector3.zero;
    private bool lookingRight = true;

    [Header("Animacion")]
    private Animator animator;

    [Header("Dash")]
    [SerializeField] public TrailRenderer trailRenderer;
    public float dashForce = 20f;
    public float dashDuration = 0.5f;

    public bool isDashing = false;
    private float dashTimer;
    private bool mayDash;
    public float dashCooldown = 2f;

    [Header("Salto")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask floor;
    [SerializeField] private Transform floorController;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool onFloor;
    private bool mayJump;


    [Header("Hook")]
    private bool onWall = false;
    private bool mayJumpOnWall = false;
    private Vector2 wallNormal;
    public float wallJumpForce = 20f;

    [Header("Wall Slide")]
    public bool isWallsliding;
    private float wallSlidingSpeed = 2f;

    [SerializeField] public GameObject wallCheck;




    void Start()
    {
        
        mayDash = true;
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }



    void Update()
    {
        CheckInputs();

        if (Input.GetButtonDown("Jump") && onFloor)
        {
            onFloor = false;
            rb2D.AddForce(new Vector2(0f, jumpForce));
            animator.SetBool("isJumping", true);
        } else
        {
            animator.SetBool("isJumping", false);
        }
    }

    void FixedUpdate()
    {
        onFloor = Physics2D.OverlapBox(floorController.position, dimensionesCaja, 0f, floor);
        //cameraPivot.localRotation = Quaternion.Euler(0f, 0f, 0f); // Mantén la rotación constante
        animator.SetFloat("yVelocity", rb2D.velocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(rb2D.velocity.x));
        
    }


    private void Movement(float move, bool jump)
    {

        Vector3 maxSpeed = new Vector2(move, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, maxSpeed, ref speed, smoothMov);

        if (move > 0 && !lookingRight)
        {
            Turn();
        }
        else if (move < 0 && lookingRight)
        {
            Turn();
        }
        //cameraPivot.localRotation = Quaternion.Euler(0f, 0f, 0f); // Mantén la rotación constante
    }


    void CheckInputs()
    {
        HorizontalMov = Input.GetAxisRaw("Horizontal") * speedMov;

        if (onWall && mayJumpOnWall && Input.GetButtonDown("Jump"))
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(new Vector2(0f, wallJumpForce));
            onWall = false;
            mayJumpOnWall = false;
        }
        if(isWallsliding)
        {
            animator.SetBool("isWallSliding", true);
        } else
        {
           animator.SetBool("isWallSliding", false);
        }

        if (Input.GetButtonDown("Dash") && mayDash)
        {
            StartCoroutine(Dash());
        }


        if (canMove)
        {
            Movement(HorizontalMov * Time.fixedDeltaTime, mayJump);

        }

        mayJump = false;
    }


    private IEnumerator Dash()
    {
        dashCooldown = 2f;
        mayDash = false;
        isDashing = true;

        float originalGravity = rb2D.gravityScale;
        rb2D.gravityScale = 0;

        rb2D.velocity = new Vector2(transform.localScale.x * dashForce, 0f);

        trailRenderer.emitting = true;

        yield return new WaitForSeconds(0.3f);

        trailRenderer.emitting = false;

        rb2D.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);

        mayDash = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            onWall = true;
            mayJumpOnWall = true;
            wallNormal = collision.contacts[0].normal;
        }

        if (collision.gameObject.CompareTag("Enemy") && isDashing)
        {
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("HOla");
            isWallsliding = true;
            rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Clamp(rb2D.velocity.y, -wallSlidingSpeed, float.MaxValue));

        }
        else
        {
            isWallsliding = false;
        }
        }




        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                onWall = false;
                mayJumpOnWall = false;
            }
        }


        private void Turn()
        {
            lookingRight = !lookingRight;
            Vector3 escale = transform.localScale;
            escale.x *= -1;
            transform.localScale = escale;

        }
}
