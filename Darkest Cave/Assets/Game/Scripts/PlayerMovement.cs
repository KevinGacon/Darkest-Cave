using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public Rigidbody2D rb2d;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;
    public Transform feetPos;
    public float checkRadius;

    public float speed;
    private float moveInput;
    public bool isGrounded =false;
    public LayerMask whatIsGround;
    public float jumpForce;
    private float jumpCounter = 0;

    public bool canDash = true;
    public float dashingTime;
    public float dashSpeed;
    public float dashJumpIncrease;
    public float timeBtwDashes;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                moveInput = Input.GetAxis("Horizontal");
                rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
            }
        }

        Flip(rb2d.velocity.x);

        float characterVelocity = Mathf.Abs(rb2d.velocity.x);
        animator.SetFloat("Speed", characterVelocity);

        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log(PlayerPrefs.GetInt("Coins"));
        }

        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log(PlayerPrefs.GetInt("LevelNumber"));
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            jumpCounter = 0;
            jumpCounter += 1;
            rb2d.velocity = Vector2.up * jumpForce;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (jumpCounter < 2)
                {
                    rb2d.velocity = Vector2.up * jumpForce;
                    jumpCounter += 1;
                }
            }
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                DashAbility();
            }
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1F)
        {
            spriteRenderer.flipX = true;
        }
    }

    void DashAbility()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        speed += dashSpeed;
        jumpForce += dashJumpIncrease;
        yield return new WaitForSeconds(dashingTime);
        speed = 140;
        jumpForce = 260;
        yield return new WaitForSeconds(timeBtwDashes);
        canDash = true;
    }
}
